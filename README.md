# AVmonitor
<h2>Данный проект состоит из двух разработок:</h2>
<ul>
  <li>Графический интерфейс</li>
  <li>Монитор</li>
</ul>
<h2>Дополнительные функции:</h2>
<ul>
  <li>Карантин</li>
  <li>Логи</li>
  <li>Деструкция первых байт</li>
  <li>Выбор области</li>
  <li>Ручная проверка файла(-ов)</li>
  <li>База сигнатур</li>
</ul>
<h3>Карантин</h3>
<p>Добавление в карантин предполагается только автоматически самим монитором. В графическом интерфейсе доступно управление списком файлов в карантине.</p>
<h3>Логи</h3>
<p>При работе любой из программ пишется журнал. Разработка использует абсолютные пути к файлам(!!!).</p>
<h3>Деструкция первых байт</h3>
<p>При обаружении вредоносного файла заменяет первые 30 байт на последовательность из "20", записывая оригиналы в специальный список</p>
<h3>Выбор области</h3>
<p>Задается в графическом интерфейсе. Требует выбор папки(либо локального диска) и тип расширения. Добавьте "*.*" если интересуют все файлы.</p>
<h3>Ручная проверка</h3>
<p>Позволяет в отдельном окне выбрать файл и проверить его. Также этот функционал доступен из меню-Файл</p>
<h3>База сигнатур</h3>
<p>Поддержка проекта не производится. База на старте пустая. При необходимости, можно взять одну из открытых баз популярных антивирусных решений и добавить к себе.</p>
