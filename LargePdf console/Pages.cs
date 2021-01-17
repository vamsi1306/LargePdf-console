using Aspose.Pdf;

namespace LargePdf_console
{
    public class Pages
    {
        #region A4
        public static PageInfo A4 = CreateA4();
        static PageInfo CreateA4()
        {
            var tempo = new PageInfo
            {
                Height = 7016,
                Width = 4960,
                Margin = NoMargin()

            };
            MarginInfo NoMargin() => new MarginInfo(50, 50, 50, 50);

            return tempo;
        }
        #endregion
    }
}
