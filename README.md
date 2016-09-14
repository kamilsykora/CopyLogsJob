# CopyLogsJob

Simple console application that can be used as an Azure webjob to copy files (e.g. logfiles) from one directory to another to avoid locking issues.

Modify the following entries in the config file for source/destination directories:

<add key="sourcepath" value="D:\home\site\wwwroot\bin\apache-tomcat-8.0.33\logs"/>
<add key="destpath" value="D:\home\site\wwwroot\bin\apache-tomcat-8.0.33\logscopy"/>
