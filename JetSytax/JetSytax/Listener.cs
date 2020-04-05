using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetSytax
{
    class Listener : GrammarBaseListener
    {
        IList<GrammarLexer> lexeme;
        public override void EnterAttribute(GrammarParser.AttributeContext context)
        {
               
            //base.EnterAttribute(context);
        }


    }
}
