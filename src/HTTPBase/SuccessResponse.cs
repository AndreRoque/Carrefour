namespace HTTPBase
{
    public class SuccessResponse : BaseResponse
    {
        #region Public Constructors

        public SuccessResponse(MessageData messageData) : base(messageData, true)
        {
            SetStatus(true);
        }

        public SuccessResponse()
        {
            SetStatus(true);
        }

        #endregion Public Constructors
    }
}