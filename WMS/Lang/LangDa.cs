using WMS.Interfaces;

namespace WMS.Lang
{
    /// <summary>
    /// This class contains the danish localization
    /// </summary>
    public class LangDa : ILang
    {
        public LangDa()
        {

        }

        public string INFORMATION { get; } = "Information";
        public string LOG { get; } = "Log";
        public string MOVE { get; } = "Flyt vare";
        public string REDUCE { get; } = "Udlevering fra lager";
        public string REGISTER { get; } = "Registrer";
        public string WASTE { get; } = "Nedskriv";
        public string MAIN { get; } = "Menu";

        public string MOVED { get; } = "Flyttet";
        public string REDUCED { get; } = "Taget";
        public string REGISTED { get; } = "Registreret";

        public string CLOSE { get; } = "Luk";
        public string ACCEPT { get; } = "Accepter";
        public string CONFIRM { get; } = "Bekræft";
        public string CANCEL { get; } = "Annuller";

        public string DESCRIPTION { get; } = "Beskrivelse";
        public string ITEM_NO { get; } = "Vare Nr.";
        public string IN_STOCK { get; } = "På lager";
        public string LOCATION { get; } = "Lokation";
        public string NEW_LOCATION { get; } = "Ny lokation";
        public string SIZE { get; } = "Størrelse";
        public string TIMESTAMP { get; } = "År-Måned-Dag Tid";
        public string USER { get; } = "Bruger";
        public string AMOUNT { get; } = "Antal";
        public string EXPECTED_AMOUNT { get; } = "Forventet antal";
        public string OPERATION { get; } = "Operation";

        public string VIEW_ITEM { get; } = "Vis vare";
        public string USAGE { get; } = "Forbrug";
        public string SORT { get; } = "Sorter";
        public string UNSORT { get; } = "Usorter";

        public string CANCELBOXTEXT { get; } = "Er du sikker på du vil annullere?";
        public string CONFIRM_TEXT { get; } = "Er du sikker på du vil fortsætte?";
        public string YES { get; } = "Ja";
        public string NO { get; } = "Nej";
        public string USER_ID { get; } = "Brugernavn";
        public string INVILD_USER_ID { get; } = "Forkert brugernavn";

        public string ERROR { get; } = "Fejl";
        public string MUST_BE_A_POSITIVE { get; } = "Skal være et positivt tal";
        public string ONLY_NUMBERS { get; } = "Skal kun være tal";
        public string MUST_BE_A_NUMER { get; } = "Skal være et nummer";
        public string SEARCH { get; } = "Søg";

        public string ORDER_NO { get; } = "Ordre Nr.";

        public string CHOOSE { get; } = "Vælg";
        public string BROKEN { get; } = "Ødelagt / I stykker";
        public string WRONG_ITEM_DELIVRED { get; } = "Modtaget forkert vare";
        public string MISSING { get; } = "Mangler";
        public string REASON { get; } = "Årsag";

        public string REMOVE_ROW { get; } = "Fjern række";

        public string SUCCESS { get; } = "Succes";
        public string SUCCESS_REDUCE { get; } = "Varer reduceret";
        public string SUCCESS_WASTE { get; } = "Varer nedskrevet";
        public string SUCCESS_MOVE { get; } = "Varer flyttet";
        public string SUCCESS_REGISTER { get; } = "Ordre registreret";

        public string IS_EMPTY { get; } = "er tom!";
        public string VALUE_IN_ITEM_ID { get; } = "Værdi i Vare Nr. i række";
        public string VALUE_IN_LOCATION { get; } = "Værdi i lokation i række";
        public string VALUE_IN_AMOUNT { get; } = "Værdi i mængde i række";
        public string VALUE_IN_NEW_LOCATION { get; } = "Værdi i ny lokation i række";
        public string ATTEMPT_TO_MOVE_FROM_SAME_LOCATION_TWICE { get; } = "Forsøgt at flytte fra samme lokation to gange";
        public string ATTEMPT_TO_MOVE_MUTIPLE_ITEM_TO_SAME_LOCATION { get; } = "Forsøgt at flytte flere varer til samme lokation";
        public string ITEM_DOES_NOT_EXIST { get; } = "Varen findes ikke";

        public string LOGGED_IN_AS { get; } = "Logget ind som:";

        public string ADD { get; } = "Tilføj række";

        public string OLD_QUANTITY { get; } = "Mængde før";
        public string NEW_QUANTITY { get; } = "Mængde efter";

        public string NOT_PLACED { get; } = "Ikke placeret";
        public string PLACED { get; } = "Placeret";
    }
}
