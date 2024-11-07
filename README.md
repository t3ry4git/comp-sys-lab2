# Лабораторна робота №2 з дисципліни «Комп’ютерні системи» «Моделювання конвеєрної обчислювальної системи»
## Варіант 22
* варіант 2

|   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 |
|---|---|---|---|---|---|---|---|---|
| 1 | * | * |   |   |   | * | * |   |
| 2 |   |   | * |   |   |   |   |   |
| 3 |   |   |   | * | * |   |   | * |
* варіант 3

|   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 |
|---|---|---|---|---|---|---|---|---|
| 1 | * |   |   |   | * |   |   | * |
| 2 |   | * |   |   |   | * |   |   |
| 3 |   |   | * | * |   |   | * |   |

## Мета
Вивчення особливостей функціонування конвеєрних обчислювальних систем. Ознайомлення з основними видами стратегії керування статичним і динамічним конвеєром. Знаходження оптимальної стратегії керування. Моделювання роботи конвеєрної обчислювальної системи.

## Загальне завдання 
1. Ознайомитися з описом лабораторної роботи.
2. Отримати варіант завдання у викладача.
3. Побудувати для таблиці зайнятості, що відповідає варіанту, повну та модифіковану діаграму станів, виписати допустимі послідовності латентностей, вибрати оптимальну. Порівняти оптимальну та жадібну стратегії.
4. Написати програму, що моделює:
* роботу статичного конвеєра, що реалізує відповідну варіанту таблицю зайнятості, з оптимальною стратегією управління;
* роботу динамічного конвеєра, що виконує випадкову рівноймовірну суміш двох таблиць зайнятості. Друга таблиця зайнятості відповідає варіанту, який слідує за вашим. (для останнього варіанту друга таблиця зайнятості вибирається відповідно до першого варіанту).

## Міні гайд
Щоб створити діаграму станів, а з неї модифіковану діаграму станів, треба трошки порахувати на листочку перед тим як малювати в draw.io
1) Порахувати відстань між зірочками
Наприклад за варіантом №2:
Перший рядок, зірочки на 0, 1, 5, 6
Обраховуємо різницю між ними
{1-0}, {5-1}, {5-0}, {6-5}, {6-1}, {6-0}
Отримуємо: 1, 4, 5, 1, 5, 6. 
Прибираємо повтори: 1, 4, 5, 6
Так само повторимо з іншими рядками.
Другой рядок: пусто
Третій рядок: 1, 3, 4
2) Тепер візьмемо всі цифри, що зустріли: 1, 3, 4, 5, 6, також додаємо 0, за замовченням. 
3) Відповідно 2 та 7 нема в цьому переліку.
* Цифри, що ми зустріли це логічні "1", а 2 та 7 це логічні "0". 
4) Підставимо їх у такому порядку від 7 до 0
5) Отримаємо значення 

|7|6|5|4|3|2|1|0|
|---|---|---|---|---|---|---|---|
|0|1|1|1|1|0|1|1|

6) Далі можна створювати діаграму станів
* Наше початкове значення зміщуємо кожен раз вліво додаючи 0 в кінці
* Якщо після зміщення перша цифра 0, то це розвилка
* Перша гілка, це ми просто і далі зміщуємо вліво
* Друга гілка, це треба провести операцію OR (початкове значення  та наше значення зі зміщенням) 
* Там де ```*``` це друга гілка, де була операція OR

7)  Модифікована діаграма станів, це ми прибираємо всі проміжні до утворення кола. Зоставити лише ті, що утворють внутрішні цикли. Кількість стрілочок, що було - це цифра яку між ними відповідно написати.
8) Відповідні латентності це цифри, що ми написали. 
* жадібна стратегія, мінімальна кількість стрілочок
* оптимальна стратегія, мінімальна кількість стрілочок + різноманіття різних кількостей стрілочок
