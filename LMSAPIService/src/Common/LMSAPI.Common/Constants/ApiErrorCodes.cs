namespace LMSAPI.Common.Constants
{
    public static class ApiErrorCodes
    {
        public const string ModelStateInvalid = "model_state_invalid";
        public const string BadRequest = "bad_request";
        public const string InternalServerError = "internal_server_error";
        public const string NotFound = "not_found";
        public const string InvalidFromDateAndToDate = "invalid_from_date_and_to_date";
        public const string InvalidLeaveType = "invalid_leave_type";
        public const string NoLeaveBalanceFound = "no_leave_balance_details_found";
        public const string LessLeaveBalance = "leave_balance_is_less";
    }
}
