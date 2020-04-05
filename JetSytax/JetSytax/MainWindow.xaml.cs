using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;
using Antlr4;
using Antlr.Runtime;

namespace JetSytax
{
	//digital : ('0' .. '9') ;
	//6.6-complete
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
		bool BW;
		Brush BA;
		public MainWindow()
        {
            InitializeComponent();
			this.Closing += Window_Closing;
			
			IsChanged = false;
			BW = true;
			BA = Mainmenu.Background;
        }

		public bool IsChanged;

		private void New_Click(object sender, RoutedEventArgs e)
		{
			if (IsChanged == true)
			{
				const string message = "Выйти без сохранения?";
				if (MessageBox.Show(message, "Exit", MessageBoxButton.YesNo) == MessageBoxResult.No)
				{
					SaveFileDialog dialogS = new SaveFileDialog();
					if (dialogS.ShowDialog() == true)
						this.Save_Click(sender, e);
				}
			}
			Code.Document = new FlowDocument(); //???
			
		}

		private void Openfile_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
			if (dialog.ShowDialog() == true)

			{
				if (IsChanged == true)
				{
					const string message = "Выйти без сохранения?";
					MessageBoxResult res = MessageBox.Show(message, "Exit", MessageBoxButton.YesNo); //обрабатывать YesNO
					if (res == MessageBoxResult.No)
					{
						SaveFileDialog dialogS = new SaveFileDialog();
						if (dialogS.ShowDialog() == true)
							this.Save_Click(sender, e);
					}
				}
				TextRange doc = new TextRange(Code.Document.ContentStart, Code.Document.ContentEnd);
				using (FileStream fileStream = new FileStream(dialog.FileName, FileMode.Open))
				{
					doc.Load(fileStream, DataFormats.Xaml);
					//FlowDocument document = System.Windows.Markup.XamlReader.Load(fileStream) as FlowDocument;
					//if (document != null)
						//Code.Document = document;
				}
				IsChanged = false;
			}
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
			if (dlg.ShowDialog() == true)
			{
				TextRange doc = new TextRange(Code.Document.ContentStart, Code.Document.ContentEnd);
				using (FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create))
				{
					//System.Windows.Markup.XamlReader.Save(fileStream);
					doc.Save(fileStream, DataFormats.Xaml);
				}
			}
			IsChanged = false;
		}

		private void Window_Closing(object sender, EventArgs e)
		{
			if (IsChanged == true)
			{
				const string message = "Выйти без сохранения?";
				if (MessageBox.Show(message, "Exit", MessageBoxButton.YesNo) == MessageBoxResult.No)
				{
					this.Save_Click(sender, new RoutedEventArgs());
				}
				IsChanged = false;
			}
		}

		private void IncreaseFontSize(object sender, RoutedEventArgs e)
		{
			Code.Selection.ApplyPropertyValue(Inline.FontSizeProperty, Code.Document.FontSize + 0.5);
		}

		private void DecreaseFontSize(object sender, RoutedEventArgs e)
		{
			Code.Selection.ApplyPropertyValue(Inline.FontSizeProperty, Code.Document.FontSize - 0.5);
		}

		private void ChangeBackground(object sender, RoutedEventArgs e)
		{
			if (BW == true)
			{
				Code.Background = new SolidColorBrush(Colors.Black);
				Code.Foreground = new SolidColorBrush(Colors.White);
				Code.BorderBrush = new SolidColorBrush(Colors.Black); 
				Mainmenu.Background = new SolidColorBrush(Colors.Black);
				Mainmenu.Foreground = new SolidColorBrush(Colors.White);
				Mainmenu.BorderBrush = new SolidColorBrush(Colors.Black);
				file.Background = new SolidColorBrush(Colors.Black);
				file.Foreground = new SolidColorBrush(Colors.White);
				file.BorderBrush = new SolidColorBrush(Colors.Black);
				newfile.Background = new SolidColorBrush(Colors.Black);
				newfile.Foreground = new SolidColorBrush(Colors.White);
				newfile.BorderBrush = new SolidColorBrush(Colors.Black);
				savefile.Background = new SolidColorBrush(Colors.Black);
				savefile.Foreground = new SolidColorBrush(Colors.White);
				savefile.BorderBrush = new SolidColorBrush(Colors.Black);
				openfile.Background = new SolidColorBrush(Colors.Black);
				openfile.Foreground = new SolidColorBrush(Colors.White);
				openfile.BorderBrush = new SolidColorBrush(Colors.Black);
				view.Background = new SolidColorBrush(Colors.Black);
				view.BorderBrush = new SolidColorBrush(Colors.Black);
				fontin.Background = new SolidColorBrush(Colors.Black);
				fontdec.Background = new SolidColorBrush(Colors.Black);
				fontdec.BorderBrush = new SolidColorBrush(Colors.Black);
				fontin.BorderBrush = new SolidColorBrush(Colors.Black);
				background.BorderBrush = new SolidColorBrush(Colors.Black);
				background.Background = new SolidColorBrush(Colors.Black);
				view.Foreground = new SolidColorBrush(Colors.White);
				grid1.Background = new SolidColorBrush(Colors.Black);
				this.Background = new SolidColorBrush(Colors.Black);
				this.BorderBrush = new SolidColorBrush(Colors.Black);
				BW = false;
			}
			else
			{
				Code.Background = new SolidColorBrush(Colors.White);
				
				Mainmenu.Background = BA;
				Mainmenu.BorderBrush = BA;
				Mainmenu.Foreground = new SolidColorBrush(Colors.Black);
				file.Background = BA;
				file.BorderBrush = BA;
				file.Foreground = new SolidColorBrush(Colors.Black);
				newfile.Background = BA;
				newfile.BorderBrush = BA;
				newfile.Foreground = new SolidColorBrush(Colors.Black);
				savefile.Background = BA;
				savefile.BorderBrush = BA;
				savefile.Foreground = new SolidColorBrush(Colors.Black);
				openfile.Background = BA;
				openfile.BorderBrush = BA;
				openfile.Foreground = new SolidColorBrush(Colors.Black);
				view.Background = BA;
				fontin.Background = BA;
				fontdec.Background = BA;
				fontdec.BorderBrush = BA;
				fontin.BorderBrush = BA;
				view.BorderBrush = BA;
				background.Background = BA;
				background.BorderBrush = BA;
				view.Foreground = new SolidColorBrush(Colors.Black);
				grid1.Background = BA;
				this.Background = BA;
				BW = true;
			}
		}

		private void Editor(object sender, RoutedEventArgs e)
		{
			IsChanged = true;
		}

		private void Highlighting(object sender, TextChangedEventArgs e)
		{
			try
			{   //ANTLRReaderStream input = new ANTLRReaderStream(Code.Document)
				string text = new TextRange(Code.Document.ContentStart, Code.Document.ContentEnd).Text;
				//ANTLRInputStream reader = new ANTLRInputStream(text);
				ANTLRStringStream input = new ANTLRStringStream(text);
				GrammarLexer lexer = new GrammarLexer((Antlr4.Runtime.ICharStream)input);
				ITokenStream tokens = new CommonTokenStream((Antlr.Runtime.ITokenSource)lexer);
				GrammarParser parser = new GrammarParser((Antlr4.Runtime.ITokenStream)tokens);
				parser.prog();

			}
			catch (Exception ex)
			{ }
		}
	}
}

