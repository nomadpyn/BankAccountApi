
namespace BankAccountApi.Models
{
    #region Public Class PageParameters

    /// <summary>
    /// Класс для осуществления постраничного вывода
    /// </summary>
    public class PageParameters
    {
        #region Private Fields

        /// <summary>
        /// Максимальное количество данных на страницу
        /// </summary>
        private const int maxPageSize = 100;

        /// <summary>
        /// Количество данных на страницу по умолчанию
        /// </summary>
        private int pageSize = 25;

        /// <summary>
        /// Номер страницы по умолчанию
        /// </summary>
        private int pageNumber = 1;

        #endregion

        #region Public Fields

        /// <summary>
        /// Свойство для номера страницы
        /// </summary>
        public int PageNumber
        {
            get
            {
                return pageNumber;
            }
            set
            {
                pageNumber = (value <= 0) ? 1 : value;
            }
        }

        /// <summary>
        /// Свойство для размера страницы
        /// </summary>
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        #endregion
    }
    #endregion
}
