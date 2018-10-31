# RS232Chat
Simple RS-232 relay chat test application.

This project is a refactoring of [graduate coursework](https://github.com/paynerg2/RS232Chat_Original).

The application is a simple, contrived example of RS-232 communication, in which data is sent over an RS-232 cable
doubled back on itself so that the data can be sent and retrieved by the same application instance.

The refactoring updates the application from WinForms to WPF, and served as a fun project to explore the [Prism Framework](https://github.com/PrismLibrary/Prism)
for implementing MVVM, navigating, and passing parameters between views, as well as async/await implementations of serial data transfer.
