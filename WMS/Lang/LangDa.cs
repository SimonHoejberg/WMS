using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Interfaces;

namespace WMS.Lang
{
    public class LangDa : ILang
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
        private string itemNo = "Vare Nr.";
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
        private string userId = "Brugernavn";
        private string invildUserId = "Forkert brugernavn";

        private string error = "Fejl";
        private string mustBePositive = "Skal være et positivt nummer";
        private string onlyNumbers = "Skriv kun tal";
        private string mustBeANumber = "Skal være et nummer";
        private string seach = "Søg";

        private string orderNo = "Ordre Nr.";

        private string choose = "Vælg";
        private string broken = "Ødelagt / I stykker";
        private string wrongItemDelivred = "Modtaget forkert vare";
        private string missing = "Mangler";
        private string reason = "Årsag";

        private string tooManyWindows = "For mange vinduere åbnet af typen";

        private string success = "Succes";
        private string successReduce = "Varer reduceret";
        private string successMove = "Varer flyttet";
        private string successWaste = "Varer nedskrevet";
        private string successRegister = "Ordre registreret";

        //Danish localization for "Move"
        private string itemsMoved = "Varer flyttet";
        private string isEmpty = "er tom!";
        private string valueItemIDError = "Værdi i Vare Nr. i række";
        private string valueLocationError = "Værdi i lokation i række";
        private string valueAmountError = "Værdi i mængde i række";
        private string valueNewLocationError = "Værdi i ny lokation i række";
        private string attemptToMoveFromSameTwice = "Forsgøt at flytte fra samme lokation to gange";
        private string attemptToMoveMutipleItemsToSameLocation = "Forsøgt at flytte flere varer til samme lokation";

        public LangDa()
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

        public string TOO_MANY_WINDOWS { get { return tooManyWindows; } }

        public string SUCCESS { get { return success; } }
        public string SUCCESS_REDUCE { get { return successReduce; } }
        public string SUCCESS_WASTE { get { return successWaste; } }
        public string SUCCESS_MOVE { get { return successMove; } }
        public string SUCCESS_REGISTER { get { return successRegister; } }

        public string ITEMS_MOVED { get { return itemsMoved; } }
        public string IS_EMPTY { get { return isEmpty; } }
        public string VALUE_IN_ITEM_ID { get { return valueItemIDError; } }
        public string VALUE_IN_LOCATION { get { return valueLocationError; } }
        public string VALUE_IN_AMOUNT { get { return valueAmountError; } }
        public string VALUE_IN_NEW_LOCATION { get { return valueNewLocationError; } }
        public string ATTEMPT_TO_MOVE_FROM_SAME_LOCATION_TWICE { get { return attemptToMoveFromSameTwice; } }
        public string ATTEMPT_TO_MOVE_MUTIPLE_ITEM_TO_SAME_LOCATION { get { return attemptToMoveMutipleItemsToSameLocation; } }
    }
}
