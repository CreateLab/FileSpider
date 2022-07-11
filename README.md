# FileSpider

Signature 
 
Требуется написать консольную программу на C# для генерации сигнатуры указанного файла. Сигнатура генерируется следующим образом: исходный файл делится на блоки заданной длины (кроме последнего блока), для каждого блока вычисляется значение hash-функции SHA256, и вместе с его номером выводится в консоль. 
 
Программа должна уметь обрабатывать файлы, размер которых превышает объем оперативной памяти, и при этом максимально эффективно использовать вычислительные мощности многопроцессорной системы. При работе с потоками допускается использовать только стандартные классы и библиотеки из .Net (исключая ThreadPool, BackgroundWorker, TPL).
 
Ожидается реализация с использованием Thread-ов. Путь до входного файла и размер блока задаются в командной строке. В случае возникновения ошибки во время выполнения программы ее текст и StackTrace необходимо вывести в консоль. 
 
Дополнительным бонусом будет постоянный порядок блоков при генерации сигнатуры. 
 
Примечание: Просьба высылать проект целиком, а не только исходные коды. 
