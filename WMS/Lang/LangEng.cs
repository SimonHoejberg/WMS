using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Interfaces;

namespace WMS.Lang
{
    public class LangEng : ILang
    {
        private string information = "Information";
        private string log = "Log";
        private string move = "Flyt Vare";
        private string reduce = "Reducer";
        private string register = "Registrer";
        private string waste = "Nedskriv";
        private string main = "Menu";

        private string moved = "Flyttet";
        private string reduced = "Taget";
        private string registed = "Registret";

        private string close = "Luk";
        private string accept = "Accepter";
        private string confirm = "Bekræft";
        private string cancel = "Annuller";

        private string description = "Beskrivelse";
        private string itemNo = "Item No.";
        private string inStock = "På lager";
        private string location = "Lokation";
        private string newLocation = "Ny Lokation";
        private string size = "Størelse";
        private string timeStamp = "Dato / Tid";
        private string user = "Bruger";
        private string amount = "Mængde";
        private string expectedAmount = "Mængde";
        private string operaton = "Operation";

        private string viewItem = "Vis Vare";
        private string usage = "Forbrug";
        private string sort = "Sorter";
        private string unsort = "Usorter";

        private string cancelBoxText = "Er du sikker på du vil annullere";
        private string yes = "Ja";
        private string no = "Nej";
        private string userId = "Bruger Navn";
        private string invildUserId = "Forkert Bruger Navn";

        private string error = "Fejl";
        private string mustBePositive = "Skal være et positivt nummer";
        private string onlyNumbers = "Skriv kun tal";
        private string mustBeANumber = "Skal være et nummer";
        private string seach = "Søg";

        private string orderNo = "Order Nr.";

        private string choose = "Vælg";
        private string broken = "Ødelagt / I stykker";
        private string wrongItemDelivred = "Modtaget forkert vare";
        private string missing = "Mangler";
        private string reason = "Årsag";

        public LangEng()
        {

        }

        public string INFORMATION { get { return information; } }
        public string LOG { get { return log; } }
        public string MOVE { get { return move; } }
        public string REDUCE { get { return reduce; } }
        public string REGISTER { get { return register; } }
        public string WASTE { get { return waste; } }
        public string MAIN { get { return main; } }

        public string MOVED { get { return moved; } }
        public string REDUCED { get { return reduced; } }
        public string REGISTED { get { return registed; } }

        public string CLOSE { get { return close; } }
        public string ACCEPT { get { return accept; } }
        public string CONFIRM { get { return confirm; } }
        public string CANCEL { get { return cancel; } }

        public string DESCRIPTION { get { return description; } }
        public string ITEM_NO { get { return itemNo; } }
        public string IN_STOCK { get { return inStock; } }
        public string LOCATION { get { return location; } }
        public string NEW_LOCATION { get { return newLocation; } }
        public string SIZE { get { return size; } }
        public string TIMESTAMP { get { return timeStamp; } }
        public string USER { get { return user; } }
        public string AMOUNT { get { return amount; } }
        public string EXPECTED_AMOUNT { get { return expectedAmount; } }
        public string OPERATION { get { return operaton; } }

        public string VIEW_ITEM { get { return viewItem; } }
        public string USAGE { get { return usage; } }
        public string SORT { get { return sort; } }
        public string UNSORT { get { return unsort; } }

        public string CANCELBOXTEXT { get { return cancelBoxText; } }
        public string YES { get { return yes; } }
        public string NO { get { return no; } }
        public string USER_ID { get { return userId; } }
        public string INVILD_USER_ID { get { return invildUserId; } }

        public string ERROR { get { return error; } }
        public string MUST_BE_A_POSITIVE { get { return mustBePositive; } }
        public string ONLY_NUMBERS { get { return onlyNumbers; } }
        public string MUST_BE_A_NUMER { get { return mustBeANumber; } }
        public string SEACH { get { return seach; } }

        public string ORDER_NO { get { return orderNo; } }

        public string CHOOSE { get { return choose; } }
        public string BROKEN { get { return broken; } }
        public string WRONG_ITEM_DELIVRED { get { return wrongItemDelivred; } }
        public string MISSING { get { return missing; } }
        public string REASON { get { return reason; } }


    }
}
