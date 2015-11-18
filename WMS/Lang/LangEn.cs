﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Interfaces;

namespace WMS.Lang
{
    public class LangEn : ILang
    {
        private string information = "Information";
        private string log = "Log";
        private string move = "Move";
        private string reduce = "Reduce";
        private string register = "Register";
        private string waste = "Waste";
        private string main = "Menu";

        private string moved = "Moved";
        private string reduced = "Taken";
        private string registed = "Registered";

        private string close = "Close";
        private string accept = "Accept";
        private string confirm = "Confirm";
        private string cancel = "Cancel";

        private string description = "Description";
        private string itemNo = "Item No.";
        private string inStock = "In stock";
        private string location = "Location";
        private string newLocation = "New location";
        private string size = "Size";
        private string timeStamp = "Date / Time";
        private string user = "User";
        private string amount = "Amount";
        private string expectedAmount = "Amount";
        private string operaton = "Operation";

        private string viewItem = "Show item";
        private string usage = "Usage";
        private string sort = "Sort";
        private string unsort = "Unsort";

        private string cancelBoxText = "Are you sure you want to cancel?";
        private string yes = "Yes";
        private string no = "No";
        private string userId = "Username";
        private string invildUserId = "Wrong username";

        private string error = "Error";
        private string mustBePositive = "Must be a positive number";
        private string onlyNumbers = "Write only numbers";
        private string mustBeANumber = "Must be a number";
        private string seach = "Search";

        private string orderNo = "Order No.";

        private string choose = "Choose";
        private string broken = "Broken";
        private string wrongItemDelivred = "Wrong item delivered";
        private string missing = "Missing";
        private string reason = "Reason";

        private string tooManyWindows = "Cannot open any more windows of the type";

        private string success = "Success";
        private string successReduce = "Successfully reduced items";
        private string successMove = "Successfully moved items";
        private string successWaste = "Successfully wasted items ";
        private string successRegister = "Successfully registered items";

        private string isEmpty = "is empty!";
        private string valueItemIDError = "Value in ItemID on row";
        private string valueLocationError = "Value in Location on row";
        private string valueAmountError = "Value in Quantity on row";
        private string valueNewLocationError = "Value in New Location on row";
        private string attemptToMoveFromSameTwice = "Attempt to move from the same location twice";
        private string attemptToMoveMutipleItemsToSameLocation = "Attempt to move multiple items to the same location";
         
        public LangEn()
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

        public string IS_EMPTY { get { return isEmpty; } }
        public string VALUE_IN_ITEM_ID { get { return valueItemIDError; } }
        public string VALUE_IN_LOCATION { get { return valueLocationError; } }
        public string VALUE_IN_AMOUNT { get { return valueAmountError; } }
        public string VALUE_IN_NEW_LOCATION { get { return valueNewLocationError; } }
        public string ATTEMPT_TO_MOVE_FROM_SAME_LOCATION_TWICE { get { return attemptToMoveFromSameTwice; } }
        public string ATTEMPT_TO_MOVE_MUTIPLE_ITEM_TO_SAME_LOCATION { get { return attemptToMoveMutipleItemsToSameLocation; } }

    }
}
