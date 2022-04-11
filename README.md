 
 Задание 1

1.Создайте форму WPF или WinForms, разместите на ней текстовое поле и в другом потоке
последовательно добавляйте на него числа Фибоначчи.
2. В этой же форме добавьте регулятор, который будет отсчитывать, сколько секунд должно
пройти, прежде чем появится следующее число.
3. Изучите внимательно статичный класс Thread и не статичный класс. Найдите метод, который
может прервать выполняющийся поток и зафиксируйте ту ошибку, которая формируется при
отмене.
4. Создайте класс-обертку над List<T>, что бы можно было добавлять и удалять элементы из
разных потоков без ошибок.
5. *Вернитесь к вашему старому проекту по отображению графиков с агентов мониторинга.
Сделайте новое приложение, которое забирает данные через потоки, не используя
async/await.


 Задание 2

1.Используя знания о пуле потоков, напишите свой микро пул с использованием новых структур
данных.
2. Добавьте в ваш пул настройку для максимального количества регистрируемых потоков или
кидайте ошибку.


Задание 3

1. Используя знания о паттернах, выберите приглянувшийся вам и создайте ICommand для WPF.


Задание 4

1. Придумайте небольшое приложение консольного типа, который берет различные Json
структуры (предположительно из разных веб сервисов), олицетворяюющие товар в магазинах.
Структуры не похожи друг на друга, но вам нужно их учесть, сделать универсально. Структуры
на ваше усмотрение.

Задача 5

1. Сделайте эмулятор устройства сканера. Он сканирует (берет данные из какого либо файла),
производит фейковые данные о загрузке процессора и памяти. Код должен быть прост, и
дальнейшую работу стоит вести только с контрактами данного устройства. Разработать
небольшую библиотеку, которая принимает от этого эмулятора байты, сохраняет в различные
форматы и мониторит его состояние, записывая в какой-либо лог.


