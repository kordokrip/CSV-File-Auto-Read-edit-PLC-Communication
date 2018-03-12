# CSVFile-Auto-Read-edit
C#,WPF

Program description

This program is a factory automation system program using UI WPF and C #.

Program operation scenario

1. The .CSV file is generated from the inspection result file in the factory automation facility.
2. After executing the program, the thread repeats every second and automatically reads and parses certain characters from the .CSV file.
3. It automatically reads and writes data by communicating with PLC and TCP / IP by converting the .CSV data that has been read automatically into bit. (It automatically executes repeatedly using a thread)
4. Communicates with Mitsubishi Q series PLC and the program keeps checking the data by thread.
