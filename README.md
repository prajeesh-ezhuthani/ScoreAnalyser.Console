# ScoreAnalyser.Console
Football score analyser program
This solution consits of 5 projects .
ScoreAnalyser.Service 
---------------------
The application logic is defined in this project . Contensts of the csv file is passed to the service method
Based on the entries , it finds the lowest difference in the goals and returns the TeamName
ScoreAnayser.Web 
--------------
This project is the UI part of the solution. 
The Score Table is displayed on the application load. The Team with lowest goal difference is Highlighted
ScoreAnalyser.Model
-----------------
This project holds the Data model used in the application
ScoreAnalyser.Console
-------------------
This is an independant project . I have tried the application logic first in the console application and tested the functional part 
Once it is confirmed that logic is correct ,used the same logic in the Service project

Common
------
This project is mainly used to read the config values . The file name is mentioned in the web.config file. 
If the users needs to use different csv, file , they just need to update this config file. No applcation rebuild required

Autofac: Autofac is used for handling dependancy injuction . The service is passed as a parameter to the consuming class. 
Based on the confiration,correct objects are executed during the run time
