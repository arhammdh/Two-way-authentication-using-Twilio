public static bool SendOtp(this string phoneNum)
{
    if (string.IsNullOrEmpty(phoneNum))
        return false;
    try
    {
        // Phone number to which you want to send the OTP
        TwilioClient.Init(Static.Settings.TwilioCredential.AccountSid, Static.Settings.TwilioCredential.AuthToken); // replace it with your credentials
        //Console.WriteLine(service.Sid);
        var verification = VerificationResource.Create(
            to: phoneNum,
            channel: "sms",
           pathServiceSid: Static.Settings.TwilioCredential.PathServciceSid
        );
        return (verification.Status == OtpStatus.Pending.ToString().ToLower());
    }
    catch (Exception ex)
    {
        throw new ApplicationException(ex.Message);
    }
}
public static bool VerifyOtp(this string Otp)
{
    TwilioClient.Init(Static.Settings.TwilioCredential.AccountSid, Static.Settings.TwilioCredential.AuthToken);// replace it with your credentials
    var verificationCheck = VerificationCheckResource.Create(
        to: "92324393939",
        code: Otp,
        pathServiceSid: Static.Settings.TwilioCredential.PathServciceSid
    );

   //implement your logic
    return (verificationCheck.Status == OtpStatus.Approved.ToString().ToLower());
}
