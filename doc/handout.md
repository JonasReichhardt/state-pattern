# State-Pattern

Jonas Reichhardt - HTL Perg - .Net C# - 12.3.2019

## Flache endliche Zustandsautomaten

In der Informatik sind Automaten abstrakte Maschinen (Realisierbarkeit dieser ist egal). Ein Zustandsautomat ist eine Art von besagten Automaten. Bei endlichen Zustandsautomaten ist die Menge der Zustände endlich und bekannt. Flache Zustandsautomaten sind nicht ineinander verschachtelt dies bedeutet das es kein Zustand wieder einen Zustandsautomaten beinhaltet.



Folgender Zustandsgraph stellt die Zustände einer Tür dar. Diese ist entweder im gesperrten Zustand oder im entsperrten Zustand.

![fsm-example](C:\repos\state-pattern\doc\graphs\fsm-example.PNG)

### Komponenten

Ein Zustandsautomat besteht aus mehreren Komponenten, deren Zusammenspiel definieren das Verhalten des Automaten. Es folgt eine Erklärung der wichtigsten Komponenten.

#### Zustände (engl. States)

Repräsentieren die Zustände des Automaten. Zustände können mit verschiedene Aktionen auf gewisse Ereignisse reagieren, diese Eigenschaft zeichnet Zustandsautomaten aus. Die Anzahl der Zustände in einem Automat sind bekannt.

#### Ereignisse (engl. Events)

Ereignisse sind Signale, welche je nach Zustand Reaktionen auslösen können.

#### Aktion (engl. Action)

Wenn der aktuelle Zustand auf das Ereignis reagiert, wird eine Aktion ausgeführt. Dies kann z.B ein Zustandsübergang sein.

#### Zustandsübergänge (engl. Transitions)

Der Zustandsautomat geht vom aktiven in einen anderen Zustand. Es kann auch in den derzeitigen Zustand übergegangen werden.

 [vgl. Manske, S.5-6]

### Erklärung

In flachen endlichen Automaten (engl.: Finite State Machines) ist die Anzahl der Zustände bekannt. Es handelt sich nicht um erweiterte, sondern um Standardautomaten. Die beschriebenen Komponenten aus dem vorherigen Abschnitt können bei der Modellierung dieser Automaten eingesetzt werden. Ein hierarchischer Aufbau der Zustände ist bei Finite State Machines (FSM) nicht vorgesehen.  Die meisten Systeme können mit Hilfe von FSM realisiert werden, jedoch ist es ab einer bestimmten Komplexität sinnvoll, auf ein erweitertes Modell zurückzugreifen. Speziell die Nutzung von geschachtelten Zuständen erleichtert oft die Modellierung von komplexen Systemen. [Manske, S.6]



## Das Zustandsentwurfsmuster

Das State-Pattern erlaubt Objekten ihr Verhalten zu ändern wenn sich der interne Zustand des Objektes verändert.  Somit gehört es zu den Verhaltensmustern unter den Entwurfsmustern welche in [GoF] beschrieben werden. Anwendung findet dieses Design Pattern bei der Implementierung von flachen endlichen Zustandsautomaten (FSM), welche auf Seite 2 erläutert werden. Zustandsautomaten werden oft für syntaktische bzw. grammatische Analysen von (Programmier)sprachen eingesetzt. Konkrete Beispiele sind JSON-Parser, SQL-Parser, Command Line Parser und Compiler/Interpreter.

### Motivation



Das Verhalten von Objekte auf verschiedene Ereignisse wird oft durch ihren Zustand bestimmt. Man nehme eine TCP Verbindung, diese hat die Zustände Established, Listening und Closed. Auf einen Open-Request wird in jedem Zustand anders reagiert. Die Schlüsselidee beim State Zustandsmuster ist eine abstrakte Klasse welche eine Schnittstelle zwischen Kontext und den konkreten Zuständen herstellt. (vgl. GoF, S.283)

![uml-chart](C:\repos\state-pattern\doc\graphs\uml-chart.png)

(GoF, S.284)

Der `Context` ruft bei einer Anfrage `state.Handle()` auf. Je nach aktueller konkreter Zustandsklasse des `Context` werden anschließend Aktionen ausgeführt.



## Implementierung eines FSM mithilfe des State-Pattern

Folgendes Beispiel implementiert einen Übersetzer welcher auf dem herkömmlichen SQL-Parser sitzt und einen  eigenen SQL-Dialekt in T-SQL-konforme Ausdrücke übersetzt. Bei diesen SQL-Dialekt haben Schlüsselwörter keine Selbstlaute (`SLCT, FRM, WHR`). Implementierungssprache ist C# unter Verwendung von Windows-Forms.

![fsm-parser](C:\repos\state-pattern\doc\graphs\fsm-parser.PNG)

Obige Grafik zeigt den Zustandsautomaten des Übersetzers.

Die Main-Klasse der Windows-Forms Anwendung ermittelt die Datenbankstruktur (Tabellennamen und deren Attribute), danach wird ein neues Parser-Objekt angelegt.

Mithilfe der Klasse Tokenizer wird der eingegebene Befehl aufgespalten und für jeden Token ruft die Main-Klasse `Parser.Parse()` auf. 

![Main](C:\repos\state-pattern\doc\graphs\Main.PNG)



Die Klasse `Parse.cs` repräsentiert den `Context` im UML-Diagramm des State-Pattern. Der `Context` hat eine Liste von allen möglichen Zuständen. Da die Anzahl an Zuständen in diesem Beispiel relativ überschaubar sind werden beim Erstellen des Parsers alle State-Klassen instanziiert.

Wenn die Parse-Methode des `Context` aufgerufen wird delegiert er den Aufruf an den derzeitigen Zustand, also das aktive State-Objekt, welche den Token überprüft. Um Zustandsänderungen herbeiführen zu können übergibt sich der `Context` der Parse-Methode des State-Objektes selbst. z.B StartState

![StartState](C:\repos\state-pattern\doc\graphs\StartState.PNG)



Die wichtigsten Objekte des `Context` Objektes. Die Liste der verfügbaren Zustände, sowie den derzeitigen Zustand.

![Context](C:\repos\state-pattern\doc\graphs\Context.PNG)



Jede State-Klasse ist eine konkrete Ausprägung der abstrakten Klasse State, wie im UML-Diagramm in [GoF] dargestellt.

![State](C:\repos\state-pattern\doc\graphs\State.PNG)





Quellen:

+ [Manske] - [Hochschule für Angewandte Wissenschaften Hamburg, Bachelorarbeit Nico Manske, Eine einfache, schnelle und speicherschonende Technologie zur Implementation des Zustands Entwurfsmusters](https://www.haw-hamburg.de/fileadmin/user_upload/TI-I/Bilder/Projekte/Faust/Arbeiten/2006/2006Ba_-_Nico_Manske_-_Eine_einfache__schnelle_und_speicherschonende_Technologie_zur_Implementation_des_Zustands-Entwurfsmusters.pdf)

  ```
  https://www.haw-hamburg.de/fileadmin/user_upload/TI-I/Bilder/Projekte/Faust/Arbeiten/2006/2006Ba_-_Nico_Manske_-_Eine_einfache__schnelle_und_speicherschonende_Technologie_zur_Implementation_des_Zustands-Entwurfsmusters.pdf
  ```

+ [GoF] - Design Patterns, Elements of reuseable Object-Oriented Software,  Erich Gamma, Richard Helm, Ralph Johnson und John Vlissides