namespace EG.Web.Core.StaticConfigs
{
    public static class JWTConfigs
    {
        public static string APIBankQuestionKey { get; set; }
        public static string APIBankQuestionIssuer { get; set; }

        public static string APISecurityJWTKey { get; set; }
        public static string APISecurityJWTIssuer { get; set; }
        public static double APISecurityJWTExpriedDays { get; set; }
        public static double APISecurityJWTExpriedHours { get; set; }
        public static double APISecurityJWTExpriedMinutes { get; set; }
    }
}
