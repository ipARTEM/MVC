 
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
