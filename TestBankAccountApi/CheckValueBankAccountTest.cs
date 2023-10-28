#region Using
using BankAccountApi.Utils;
using TestBankAccountApi.Factorys;
#endregion

namespace TestBankAccountApi
{
    #region Public Class CheckValueBankAccountTest

    /// <summary>
    /// ����� ��� ������������ �������� bankaccount
    /// </summary>
    public class CheckValueBankAccountTest
    {
        #region Private Fields
        /// <summary>
        /// ������� ��� �������� ����������� bankaccount
        /// </summary>
        private BankAccountFactory? factory = new();
        #endregion

        #region Public Methods

        /// <summary>
        /// ���� CheckNewBankAccount �� ���������� bankaccount
        /// </summary>
        [Fact]
        public void TestCheckNewBankAccountCorrect()
        {
            var account = factory.CreateCorrectBankAccount();

            Assert.True(CheckValue.CheckNewBankAccount(account));
        }

        /// <summary>
        /// ���� CheckNewBankAccount �� null bankaccount
        /// </summary>
        [Fact]
        public void TestCheckNewBankAccountNull()
        {
            var account = factory.CreateNullBankAccount();

            Assert.False(CheckValue.CheckNewBankAccount(account));
        }

        /// <summary>
        /// ���� CheckNewBankAccount �� ������ bankaccount
        /// </summary>
        [Fact]
        public void TestCheckNewBankAccountEmpty()
        {
            var account = factory.CreateEmptyBankAccount();

            Assert.False(CheckValue.CheckNewBankAccount(account));
        }

        /// <summary>
        /// ���� CheckNewBankAccount �� bankaccount � ������������ ������ �� �����
        /// </summary>
        [Fact]
        public void TestCheckNewBankAccountIncorrectAmount()
        {
            var account = factory.CreateIncorrectAmountBankAccount();

            Assert.False(CheckValue.CheckNewBankAccount(account));
        }

        /// <summary>
        /// ���� CheckNewBankAccount �� bankaccount � ������������ ������� �����
        /// </summary>
        [Fact]
        public void TestCheckNewBankAccountIncorrectAccountNumber()
        {
            var account = factory.CreateIncorrectAccountNumberBankAccount();

            Assert.False(CheckValue.CheckNewBankAccount(account));
        }

        /// <summary>
        /// ���� CheckNewBankAccount �� bankaccount � ������������ ������ �� ����� � ������������ ������� �����
        /// </summary>
        [Fact]
        public void TestCheckNewBankAccountIncorrectAll()
        {
            var account = factory.CreateIncorrectAllBankAccount();

            Assert.False(CheckValue.CheckNewBankAccount(account));
        }

        /// <summary>
        /// ���� CheckEmptyBankAccount �� ���������� bankaccount
        /// </summary>
        [Fact]
        public void TestCheckEmptyBankAccountCorrect()
        {
            var account = factory.CreateCorrectBankAccount();

            Assert.False(CheckValue.CheckEmptyBankAccount(account));
        }

        /// <summary>
        /// ���� CheckEmptyBankAccount �� null bankaccount
        /// </summary>
        [Fact]
        public void TestCheckEmptyBankAccountNull()
        {
            var account = factory.CreateNullBankAccount();

            Assert.True(CheckValue.CheckEmptyBankAccount(account));
        }

        /// <summary>
        /// ���� CheckEmptyBankAccount �� ������ bankaccount
        /// </summary>
        [Fact]
        public void TestCheckEmptyBankAccountEmpty()
        {
            var account = factory.CreateEmptyBankAccount();

            Assert.True(CheckValue.CheckEmptyBankAccount(account));
        }

        /// <summary>
        /// ���� CheckEmptyBankAccount �� bankaccount � ������������ ������ �� �����
        /// </summary>
        [Fact]
        public void TestCheckEmptyBankAccountIncorrectAmount()
        {
            var account = factory.CreateIncorrectAmountBankAccount();

            Assert.False(CheckValue.CheckEmptyBankAccount(account));
        }

        /// <summary>
        /// ���� CheckEmptyBankAccount �� bankaccount � ������������ ������� �����
        /// </summary>
        [Fact]
        public void TestCheckEmptyBankAccountIncorrectAccountNumber()
        {
            var account = factory.CreateIncorrectAccountNumberBankAccount();

            Assert.False(CheckValue.CheckEmptyBankAccount(account));
        }

        /// <summary>
        /// ���� CheckEmptyBankAccount �� bankaccount � ������������ ������ �� ����� � ������������ ������� �����
        /// </summary>
        [Fact]
        public void TestCheckEmptyBankAccountIncorrectAll()
        {
            var account = factory.CreateIncorrectAllBankAccount();

            Assert.False(CheckValue.CheckEmptyBankAccount(account));
        }
        #endregion
    }
    #endregion
}