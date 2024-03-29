﻿
namespace WMS.Interfaces
{
    /// <summary>
    /// A interface which can be used to create localization for languages
    /// </summary>
    public interface ILang
    {
        string INFORMATION { get; }
        string LOG { get; }
        string MOVE { get; }
        string REDUCE { get; }
        string REGISTER { get; }
        string WASTE { get; }
        string MAIN { get; }

        string MOVED { get; }
        string REDUCED { get; }
        string REGISTED { get; }

        string CLOSE { get; }
        string ACCEPT { get; }
        string CONFIRM { get; }
        string CANCEL { get; }

        string DESCRIPTION { get; }
        string ITEM_NO { get; }
        string IN_STOCK { get; }
        string LOCATION { get; }
        string NEW_LOCATION { get; }
        string SIZE { get; }
        string TIMESTAMP { get; }
        string USER { get; }
        string AMOUNT { get; }
        string EXPECTED_AMOUNT { get;}
        string OPERATION { get; }

        string VIEW_ITEM { get; }
        string USAGE { get; }
        string SORT { get; }
        string UNSORT { get; }

        string CANCELBOXTEXT { get; }
        string CONFIRM_TEXT { get; }
        string YES { get; }
        string NO { get; }
        string USER_ID { get; }
        string INVILD_USER_ID { get; }

        string ERROR { get; }
        string MUST_BE_A_POSITIVE { get; }
        string ONLY_NUMBERS { get; }
        string MUST_BE_A_NUMER { get; }
        string SEARCH { get; }
        string ADD { get; }

        string ORDER_NO { get; }

        string CHOOSE { get; }
        string BROKEN { get; }
        string WRONG_ITEM_DELIVRED { get; }
        string MISSING { get; }
        string REASON { get; }

        string REMOVE_ROW { get; }

        string SUCCESS { get; }
        string SUCCESS_REDUCE { get; }
        string SUCCESS_WASTE { get; }
        string SUCCESS_MOVE { get; }
        string SUCCESS_REGISTER { get; }

        string IS_EMPTY { get; }
        string VALUE_IN_ITEM_ID { get; }
        string VALUE_IN_LOCATION { get; }
        string VALUE_IN_AMOUNT { get; }
        string VALUE_IN_NEW_LOCATION { get; }
        string ATTEMPT_TO_MOVE_FROM_SAME_LOCATION_TWICE { get; }
        string ATTEMPT_TO_MOVE_MUTIPLE_ITEM_TO_SAME_LOCATION { get; }
        string ITEM_DOES_NOT_EXIST { get; }

        string OLD_QUANTITY { get; }
        string NEW_QUANTITY { get; }

        string LOGGED_IN_AS { get; }

        string NOT_PLACED { get; }
        string PLACED { get; }
    }
}
