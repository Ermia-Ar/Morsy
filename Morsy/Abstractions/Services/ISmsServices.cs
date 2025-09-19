namespace Morsy.Abstractions.Services;

public interface ISmsServices
{
    /// <summary>
    /// متد ارسال پیام
    /// </summary>
    /// <param name="senderNumber">شماره خط ارسال کننده پیام</param>
    /// <param name="mobileNumbers">شماره های دریافت کننده پیام</param>
    /// <param name="message">متن پیامک</param>
    /// <param name="sendToBlocksNumber">ارسال به شماره های بلاک شده</param>
    /// <param name="sendTimeSpan">زمان ارسال پیام</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SendSmsResponseDto> SendSmsAsync( 
        string senderNumber ,
        List<string> mobileNumbers  ,
        string message ,
        bool sendToBlocksNumber ,
        double? sendTimeSpan , 
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// متد ارسال پیام متناظر
    /// </summary>
    /// <param name="senderNumber">شماره خط ارسال کننده پیام</param>
    /// <param name="mobileNumbers">شماره های دریافت کننده پیام</param>
    /// <param name="messages">متن پیام ها</param>
    /// <param name="sendToBlocksNumber">ارسال به شماره های بلاک شده</param>
    /// <param name="sendTimeSpan">زمان ارسال پیام</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SendP2PResponseDto> SendP2PAsync(
        string senderNumber ,
        List<string> mobileNumbers,
        List<string> messages,
        bool sendToBlocksNumber,
        double? sendTimeSpan,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="otpId">شناسه متن پیام</param>
    /// <param name="mobileNumber">شماره دریافت کننده پیام</param>
    /// <param name="replaceTokens">متن های جایگذین</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SendPatternResponseDto> SendPatternAsync(
        long otpId, 
        string mobileNumber ,
        List<object> replaceTokens, 
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// متد دریافت وضعیت ارسال
    /// </summary>
    /// <param name="messageIds">شناسه پیام های ارسالی</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<GetStatusResponseDto> GetStatusAsync(
        List<string> messageIds,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// متد دریافت اطلاعات پروفایل
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<GetCreditResponseDto> GetCreditAsync(
        CancellationToken cancellationToken = default);

    /// <summary>
    /// ارسال پیام تکی و گروهی از طریق نرم‌افزار هلو
    /// </summary>
    /// <param name="senderNumber">	شماره خط ارسال کننده پیام</param>
    /// <param name="mobileNumberS">شماره های دریافت کننده پیام</param>
    /// <param name="message">متن پیام</param>
    /// <param name="apiKey">کد دسترسی شما</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SendFromFromResponseDto> SendFromFromAsync(
        string senderNumber,
        List<string> mobileNumberS,
        string message,
        string apiKey,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// متد احراز هویت
    /// </summary>
    /// <param name="mobileNumber">شماره موبایل دریافت کننده کد</param>
    /// <param name="footer">متن فوتر در پیام</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SendCodeResponseDto> SendCodeAsync(
        string mobileNumber,
        string footer,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// متد دریافت وضعیت احراز هویت
    /// </summary>
    /// <param name="mobileNumber">شماره موبایل دریافت کننده کد</param>
    /// <param name="code">کد وارد شده توسط کاربر</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CheckCodeResponseDto> CheckCodeAsync(
        string mobileNumber,
        string code,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// متد دریافت پیام های دریافتی
    /// </summary>
    /// <param name="number">شماره ی اختصاصی</param>
    /// <param name="pageSize">شماره صفحه</param>
    /// <param name="pageNumber">تعداد</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<GetReceivedMessageResponseDto> GetReceivedMessageAsync(
        string number,
        int pageSize,
        int pageNumber,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mobileNumber">شماره خط دریافت کننده پیام</param>
    /// <param name="generationCode">کد اعتبارسنجی</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SendOtpVoiceResponseDto> SendOtpVoiceAsync(
        string mobileNumber,
        string? generationCode,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// لغو پیام تکی زمانبندی شده
    /// </summary>
    /// <param name="messageId">آیدی پیام</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<CancelUserOneMessageResponseDto> CancelUserOneMessageAsync(
        long messageId,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// متد ارسال پیام صوتی
    /// </summary>
    /// <param name="voiceId">آیدی صوتی که قرار است ارسال شود</param>
    /// <param name="mobileNumbers">شماره های دریافت کننده پیام</param>
    /// <param name="maxTry">تعداد تلاش برای تماس</param>
    /// <param name="minuteBetweenTries">فاصله زمانی بین هر تلاش برای تماس به دقیقه</param>
    /// <param name="startTimeSpan">زمان شروع ارسال</param>
    /// <param name="endTimeSpan">زمان پایان ارسال</param>
    /// <param name="hasVote"> درصورتی که این تماس همراه با نظرسنجی می باشد باید درست ارسال شود</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SendVoiceResponseDto> SendVoiceAsync(
        long voiceId,
        List<string> mobileNumbers,
        short maxTry,
        int minuteBetweenTries,
        double startTimeSpan,
        double endTimeSpan,
        bool hasVote,
        CancellationToken cancellationToken = default);
}