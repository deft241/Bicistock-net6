namespace Capa_Soporte.Helpers
{
    public static class MailTemplate
    {
        //Template for the emails
        public static readonly string CODE_EMAIL = @"
                                <!DOCTYPE html>
                                <html>
                                <head>
                                    <meta charset=""UTF-8"">
                                    <style>
                                        
                                        body {
                                            font-family: ""Segoe UI"", Arial, sans-serif;
                                        }

                                       
                                        .container {
                                            max-width: 600px;
                                            margin: 0 auto;
                                            padding: 20px;
                                            background-color: #f5f5f5;
                                            border-radius: 5px;
                                        }

                                        
                                        .header {
                                            text-align: center;
                                            margin-bottom: 20px;
                                        }

                                        .header h1 {
                                            color: #333;
                                        }

                                        
                                        .content {
                                            background-color: #fff;
                                            padding: 20px;
                                            border-radius: 5px;
                                        }

                                        .content p {
                                            color: #555;
                                        }

                                        
                                        .footer {
                                            text-align: center;
                                            margin-top: 20px;
                                            color: #888;
                                        }
                                    </style>
                                </head>
                                <body>
                                    <div class=""container"">
                                        <div class=""header"">
                                            <h1>Activación de su Cuenta Bicistock</h1>
                                        </div>
                                        <div class=""content"">
                                            <p>Codigo de verificación [[CODE]]</p>  
                                        </div>
                                        <div class=""footer"">
                                            <p>© [[YEAR]] Bicistock. Todos los derechos reservados.</p>
                                        </div>
                                    </div>
                                </body>
                                </html>";

        public static readonly string REMOVE_APPOINTMENT_EMAIL = @"
                                <!DOCTYPE html>
                                <html>
                                <head>
                                    <meta charset=""UTF-8"">
                                    <style>
                                        
                                        body {
                                            font-family: ""Segoe UI"", Arial, sans-serif;
                                        }

                                       
                                        .container {
                                            max-width: 600px;
                                            margin: 0 auto;
                                            padding: 20px;
                                            background-color: #f5f5f5;
                                            border-radius: 5px;
                                        }

                                        
                                        .header {
                                            text-align: center;
                                            margin-bottom: 20px;
                                        }

                                        .header h1 {
                                            color: #333;
                                        }

                                        
                                        .content {
                                            background-color: #fff;
                                            padding: 20px;
                                            border-radius: 5px;
                                        }

                                        .content p {
                                            color: #555;
                                        }

                                        
                                        .footer {
                                            text-align: center;
                                            margin-top: 20px;
                                            color: #888;
                                        }
                                    </style>
                                </head>
                                <body>
                                    <div class=""container"">
                                        <div class=""header"">
                                            <h1>Su cita ha sido eliminada</h1>
                                        </div>
                                        <div class=""content"">
                                            <p>Su cita ha sido eliminada por un administrador. Esto es posible ya que esa hora no estaba disponible o por que se ha detectado información falsa</p>  
                                            <br>
                                            <br>
                                            <p>Puede solicitar una nueva cita en su perfil, o si el problema es recurrente, contacte a bicistock@outlook.es</p>  
                                        </div>
                                        <div class=""footer"">
                                            <p>© [[YEAR]] Bicistock. Todos los derechos reservados.</p>
                                        </div>
                                    </div>
                                </body>
                                </html>";

        public static readonly string APPOINTMENT_EMAIL = @"
                                <!DOCTYPE html>
                                <html>
                                <head>
                                    <meta charset=""UTF-8"">
                                    <style>
                                        
                                        body {
                                            font-family: ""Segoe UI"", Arial, sans-serif;
                                        }

                                       
                                        .container {
                                            max-width: 600px;
                                            margin: 0 auto;
                                            padding: 20px;
                                            background-color: #f5f5f5;
                                            border-radius: 5px;
                                        }

                                        
                                        .header {
                                            text-align: center;
                                            margin-bottom: 20px;
                                        }

                                        .header h1 {
                                            color: #333;
                                        }

                                        
                                        .content {
                                            background-color: #fff;
                                            padding: 20px;
                                            border-radius: 5px;
                                        }

                                        .content p {
                                            color: #555;
                                        }

                                        
                                        .footer {
                                            text-align: center;
                                            margin-top: 20px;
                                            color: #888;
                                        }
                                    </style>
                                </head>
                                <body>
                                    <div class=""container"">
                                        <div class=""header"">
                                            <h1>Detalles Cita</h1>
                                        </div>
                                        <div class=""content"">
                                            <p><b>ID de la cita :</b> [[ID_APPOINTMENT]]</p>
                                            <p><b>Usuario Solicitante :</b> [[USER_APPOINTMENT]]</p>
                                            <p><b>Marca Bicicleta :</b> [[BRAND_APPOINTMENT]]</p>
                                            <p><b>Fecha Solicitada :</b> [[DATE_APPOINTMENT]]</p>
                                            <p><b>Hora Solicitada :</b> [[HOUR_APPOINTMENT]]</p>
                                            <p>Le recomendamos que acuda 5 minutos antes de la hora solicitada, para evitar retrasos inesperados.</p>

                                            <p>Conserve este correo ya que nuestros empleados deben validar la cita</p>
                                        </div>
                                        <div class=""footer"">
                                            <p>© [[YEAR]] Bicistock. Todos los derechos reservados.</p>
                                        </div>
                                    </div>
                                </body>
                                </html>";
    }
}
