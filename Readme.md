This is a sample conosole application that calculating the licenses required for the application with ID 374.
The output appears in the console itself.

Application on DDEBUG build will explain how it got to the licensing position.

This application will take care of the duplicates if any in the File .

The application takes in 2 arguments 1st is the path to the csv file and the second is the applicationID for which the License needs to be calculated.

Sample :- CodeTest.exe "Path to the CSV" "374"
By default application look at the current directory for the csv file . 

The csv file is assumed to have the values in the following order of the columns :-

ComputerID, UserID, ApplicationID, ComputerType, Comments.

Unit Tests cover the basic requirement :-

Test CSV files are also present in the DEBUG folder for the builds of the tests.

1.Checking for duplicates
2.Checking to see if the relations between user and computers is correct. Ans the user counts are correct.
3.Checking to see if the License count for the sample data is correct.  

-- AUTHOR 
ANUBHAV MEENA  