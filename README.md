![image](https://github.com/Ostroh-Academy/09-decorator-VitaliiLitvinchuk/assets/145115691/67a01ff8-87b5-4e17-9a7b-ff5cddd1bf46)

IDataConverter (інтерфейс)
Цей інтерфейс визначає контракт для перетворення даних з одного формату в інший. Він містить метод ConvertData, який приймає рядок як вхідний параметр (data) і повертає конвертований рядок у бажаному форматі.

JsonToXmlConverter (клас)
Цей клас реалізує інтерфейс IDataConverter. Він перетворює дані JSON (jsonData) у формат XML за допомогою JsonConvert.DeserializeXNode. Перед конвертуванням видаляє пробіли з вхідних даних JSON.

XmlToJsonConverter (клас)
Цей клас реалізує інтерфейс IDataConverter. Він перетворює дані XML (xmlData) у формат JSON за допомогою JsonConvert.SerializeXNode. Перед конвертуванням розбирає вхідні дані XML за допомогою XDocument.Parse.

SerializeDecorator (клас)
Цей клас обертає об'єкт IDataConverter і надає додаткові функції (шаблон декоратора). Він тримає посилання на екземпляр IDataConverter (_converter) у своєму конструкторі. Метод ConvertData делегує конвертування базовому об'єкту _converter.

Відносини між класами
IDataConverter - це абстрактна концепція, реалізована конкретними класами конвертерів, такими як JsonToXmlConverter та XmlToJsonConverter.
SerializeDecorator має композиційні відносини з IDataConverter. Він приймає об'єкт IDataConverter як вхідний параметр у своєму конструкторі та використовує його для конвертування.
