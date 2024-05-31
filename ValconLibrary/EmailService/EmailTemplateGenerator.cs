using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using ValconLibrary.Entities;

namespace ValconLibrary.EmailService
{
    public class EmailTemplateGenerator
    {
        public static AlternateView GenerateBookRentConfirmationEmail(string userName, Book book, BookRent rent, string path)
        {
            LinkedResource img = new LinkedResource(path, MediaTypeNames.Image.Jpeg)
            {
                ContentId = Guid.NewGuid().ToString() 
            };
            string str = $@"
        <html>
        <head>
            <style>
                body {{
                    font-family: Arial, sans-serif;
                    margin: 0;
                    padding: 0;
                    background-color: #f4f4f4;
                }}
                .email-container {{
                    max-width: 600px;
                    margin: auto;
                    padding: 20px;
                    background-color: #000000;
                    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                }}
                .header {{
                    background-color: #cccccc;
                    color: black;
                    padding: 10px;
                    text-align: center;
                }}
                .content {{
                    padding: 20px;
                    text-align: left;
                    color: #cccccc;
                }}
                .footer {{
                    background-color: #363636;
                    text-align: center;
                    padding: 10px;
                    margin-top: 20px;
                    font-size: 12px;
                    color: #cccccc;
                }}
                .book-cover {{
                    display: block;
                    margin-left: auto;
                    margin-right: auto;
                    width: 50%;
                    max-width: 200px;
                    height: auto;
                }}
            </style>
        </head>
        <body>
            <div class='email-container'>
                <div class='header'>
                    <h1>Library Practice</h1>
                </div>
                <div class='content'>
                    <p>Dear {userName},</p>
                    <p>We are pleased to inform you that you have successfully rented the book <strong>{book.Title}</strong>.</p>
                    <img src='cid:{img.ContentId}' alt='Book Cover' class='book-cover' width='100px' height='100px'/>
                    <p><strong>Book Details:</strong></p>
                    <ul>
                        <li><strong>Title:</strong> {book.Title}</li>
                        <li><strong>ISBN:</strong> {book.ISBN}</li>
                        <li><strong>Genre:</strong> {book.Genre}</li>
                        <li><strong>Number of Pages:</strong> {book.NumberOfPages}</li>
                        <li><strong>Publishing Year:</strong> {book.PublishingYear}</li>
                    </ul>
                    <p>The rental date is: {rent.RentDate.ToShortDateString()}</p>
                    <p>The rental period is: <strong>{rent.RentalPeriodInDays.ToString()}</strong> day/s.</p>
                    <p>Thank you for using our library services.</p>
                    <p>Best regards,<br />Valcon Library</p>
                </div>
                <div class='footer'>
                    <p>Valcon Library | Address: Bulevar Mihajla Pupina 1, Novi Sad | Contact Info: valcon.practice@valcon.com</p>
                </div>
            </div>
        </body>
        </html>";

            AlternateView aV =
            AlternateView.CreateAlternateViewFromString(str, null, MediaTypeNames.Text.Html);
            aV.LinkedResources.Add(img);

            return aV;
        }
    }
}
