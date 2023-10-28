# BankAccountApi

Требуется разработать интерфейс в виде REST API на .Net Core 6 или 7 для внесения платежей. К реализации следует подойти также, как и к реальной задаче – продумать архитектуру для дальнейшего расширения, покрыть код тестами.

Требуется реализовать следующие методы:
- Снятие/добавление суммы на счёт;
- Вывод текущего баланса;
- Получение транзакций с возможностью постраничного вывода, сортировки.

Следует предусмотреть валидацию данных (проверка, что средств на счёте достаточно; существование счёта для транзакции и т.д.).
У создаваемого приложения должна быть база данных. Можно использовать любую СУБД.
