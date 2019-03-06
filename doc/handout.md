# State-Pattern

Jonas Reichhardt - HTL Perg - .Net C# - 12.3.2019



Das State-Pattern erlaubt Objekten ihr Verhalten zu ändern wenn sich der interne Zustand des Objektes verändert. Anwendung findet dieses Design Pattern bei der Implementierung von flachen endlichen Zustandsautomaten (FSM), welche auf Seite 2 erläutert werden. Zustandsautomaten werden oft für syntaktische bzw. grammatische Analysen von (Programmier)sprachen eingesetzt. Konkrete Beispiele sind JSON-Parser, SQL-Parser, Command Line Parser und Compiler/Interpreter.

### Motivation



Das Verhalten von Objekte auf verschiedene Ereignisse wird oft durch ihren Zustand bestimmt. Man nehme eine TCP Verbindung, diese hat die Zustände Established, Listening und Closed. Auf einen Open-Request wird in jedem Zustand anders reagiert. Die Schlüsselidee beim State Zustandsmuster ist eine abstrakte Klasse welche eine Schnittstelle zwischen Kontext und den konkreten Zuständen herstellt. (vgl. GoF, S.283)

![On Java Hell: A simple example of the State Design Pattern ...](https://proxy.duckduckgo.com/iu/?u=http%3A%2F%2Fupload.wikimedia.org%2Fwikipedia%2Fcommons%2F9%2F90%2FState_Design_Pattern_UML_Class_Diagram.png&f=1)

Der `Context` ruft bei einer Anfrage `state.Handle()` auf. Je nach aktueller konkreter Zustandsklasse des `Context` werden anschließend Aktionen ausgeführt.





## Flache endliche Zustandsautomaten

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

![fsm-example](C:\repos\state-pattern\doc\graphs\fsm-example.PNG)

## Implementierung eines FSM mithilfe des State-Pattern



###TODO - Beschreibung des Beispiel





Quellen:

+ [Manske] - [Hochschule für Angewandte Wissenschaften Hamburg, Bachelorarbeit Nico Manske, Eine einfache, schnelle und speicherschonende Technologie zur Implementation des Zustands Entwurfsmusters](https://www.haw-hamburg.de/fileadmin/user_upload/TI-I/Bilder/Projekte/Faust/Arbeiten/2006/2006Ba_-_Nico_Manske_-_Eine_einfache__schnelle_und_speicherschonende_Technologie_zur_Implementation_des_Zustands-Entwurfsmusters.pdf)

  ```
  https://www.haw-hamburg.de/fileadmin/user_upload/TI-I/Bilder/Projekte/Faust/Arbeiten/2006/2006Ba_-_Nico_Manske_-_Eine_einfache__schnelle_und_speicherschonende_Technologie_zur_Implementation_des_Zustands-Entwurfsmusters.pdf
  ```

+ [GoF] - Design Patterns, Elements of reuseable Object-Oriented Software,  Erich Gamma, Richard Helm, Ralph Johnson und John Vlissides