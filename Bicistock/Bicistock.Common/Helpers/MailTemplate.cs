namespace Capa_Soporte.Helpers
{
    public static class MailTemplate
    {
        public static readonly string CONFIRMATION_EMAIL = @"<!DOCTYPE html>
                                <html>
                                <head>
                                    <style>
                                        table {
                                          font-family: arial, sans-serif;
                                          border-collapse: collapse;
                                          width: 100%;
                                        }
                                    </style>
                                </head>
                                <body>
                                    <p>Codigo de verificación [[CODE]]</p>
                                </body>
                                </html>";
    }
}
