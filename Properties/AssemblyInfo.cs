﻿/*
30.04.2023 0.2 Добавлен поиск по базе, удалены P2SH
01.05.2023 0.3 Вместо кнопок - холст для рисования
SEGWIT BECH32 должны создаваться из СЖАТОГО ключа иначе монеты станут недоступны!
04.05.2023 0.4
 * */

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Общие сведения об этой сборке предоставляются следующим набором
// набора атрибутов. Измените значения этих атрибутов для изменения сведений,
// связанных со сборкой.
[assembly: AssemblyTitle("BitCraft")]
[assembly: AssemblyDescription("Manual bitcoin crafting")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("HomeSoft")]
[assembly: AssemblyProduct("BitCraft")]
[assembly: AssemblyCopyright("Copyright ©  2023")]
[assembly: AssemblyTrademark("HomeSoft")]
[assembly: AssemblyCulture("")]

// Установка значения False для параметра ComVisible делает типы в этой сборке невидимыми
// для компонентов COM. Если необходимо обратиться к типу в этой сборке через
// COM, следует установить атрибут ComVisible в TRUE для этого типа.
[assembly: ComVisible(false)]

// Следующий GUID служит для идентификации библиотеки типов, если этот проект будет видимым для COM
[assembly: Guid("feeefe4c-2c17-4c23-991b-47c939a5167a")]

// Сведения о версии сборки состоят из указанных ниже четырех значений:
//
//      Основной номер версии
//      Дополнительный номер версии
//      Номер сборки
//      Редакция
//
// Можно задать все значения или принять номера сборки и редакции по умолчанию 
// используя "*", как показано ниже:
// [assembly: AssemblyVersion("1.0.*")]
//[assembly: AssemblyVersion("1.0.0.0")]
//[assembly: AssemblyFileVersion("1.0.0.0")]
