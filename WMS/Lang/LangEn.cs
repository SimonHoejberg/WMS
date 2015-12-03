using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Interfaces;

namespace WMS.Lang
{
    /// <summary>
    /// This class contains the english localization
    /// </summary>
    public class LangEn : ILang
    {
        public LangEn()
        {

        }

        public string INFORMATION { get; } = "Information";
        public string LOG { get; } = "Log";
        public string MOVE { get; } = "Move";
        public string REDUCE { get; } = "Reduce";
        public string REGISTER { get; } = "Register";
        public string WASTE { get; } = "Waste";
        public string MAIN { get; } = "Menu";

        public string MOVED { get; } = "Moved";
        public string REDUCED { get; } = "Taken";
        public string REGISTED { get; } = "Registered";

        public string CLOSE { get; } = "Close";
        public string ACCEPT { get; } = "Accept";
        public string CONFIRM { get; } = "Confirm";
        public string CANCEL { get; } = "Cancel";

        public string DESCRIPTION { get; } = "Description";
        public string ITEM_NO { get; } = "Item No";
        public string IN_STOCK { get; } = "In Stock";
        public string LOCATION { get; } = "Location";
        public string NEW_LOCATION { get; } = "New Location";
        public string SIZE { get; } = "Size";
        public string TIMESTAMP { get; } = "Year-Month-Day Time";
        public string USER { get; } = "User";
        public string AMOUNT { get; } = "Amount";
        public string EXPECTED_AMOUNT { get; } = "Expected amount";
        public string OPERATION { get; } = "Operation";

        public string VIEW_ITEM { get; } = "Show Item";
        public string USAGE { get; } = "Usage";
        public string SORT { get; } = "Sort";
        public string UNSORT { get; } = "Unsort";

        public string CANCELBOXTEXT { get; } = "Are you sure you want to cancel?";
        public string CONFIRM_TEXT { get; } = "Are you sure you want to continue?";
        public string YES { get; } = "Yes";
        public string NO { get; } = "No";
        public string USER_ID { get; } = "Username";
        public string INVILD_USER_ID { get; } = "Wrong username";

        public string ERROR { get; } = "Error";
        public string MUST_BE_A_POSITIVE { get; } = "Must be a positive number";
        public string ONLY_NUMBERS { get; } = "Write only numbers";
        public string MUST_BE_A_NUMER { get; } = "Must be a number";
        public string SEARCH { get; } = "Search";

        public string ORDER_NO { get; } = "Order No.";

        public string CHOOSE { get; } = "Choose";
        public string BROKEN { get; } = "Broken";
        public string WRONG_ITEM_DELIVRED { get; } = "Wrong item delivered";
        public string MISSING { get; } = "Missing";
        public string REASON { get; } = "Reason";

        public string REMOVE_ROW { get; } = "Remove row";

        public string SUCCESS { get; } = "Success";
        public string SUCCESS_REDUCE { get; } = "Successfully reduced items";
        public string SUCCESS_WASTE { get; } = "Successfully moved items";
        public string SUCCESS_MOVE { get; } = "Successfully wasted items";
        public string SUCCESS_REGISTER { get; } = "Successfully registered items";

        public string IS_EMPTY { get; } = "is empty!";
        public string VALUE_IN_ITEM_ID { get; } = "Value in Item No. on row";
        public string VALUE_IN_LOCATION { get; } = "Value in Location on row";
        public string VALUE_IN_AMOUNT { get; } = "Value in Quantity on row";
        public string VALUE_IN_NEW_LOCATION { get; } = "Value in New Location on row";
        public string ATTEMPT_TO_MOVE_FROM_SAME_LOCATION_TWICE { get; } = "Attempt to move from same location twice";
        public string ATTEMPT_TO_MOVE_MUTIPLE_ITEM_TO_SAME_LOCATION { get; } = "Attempt to move multiple items to the same location";

        public string LOGGED_IN_AS { get; } = "Logged in as:";

        public string ADD { get; } = "Add row";

        public string OLD_QUANTITY { get; } = "Old quantity";
        public string NEW_QUANTITY { get; } = "New quantity";

        public string NOT_PLACED { get; } = "Not placed";
        public string PLACED { get; } = "Placed";
    }
}
