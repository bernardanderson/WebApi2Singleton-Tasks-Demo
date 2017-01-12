# Basic WebAPI2 Demo with Singleton Access and Tasks

The basic demo shows how the implementation of a singleton class can be used to store the cancellation token for a running task

> 1. Download or Clone This Repo  
> 2. `dotnet restore` to restore packages
> 3. `dotnet run` to run (point your browser to localhost:5000)

This demo utilizes Background threads/Tasks in order to count and store a List<> of numbers. A singleton is used to store a Model containing a user name and the CancellationTokenSource related to the counting Thread associated with that user. The singleton also stores a List of ints accessible by all API queries.

1. You can start the recording of numbers for a specific user using `/api/values/{userName}/start`  
1. You can stop the recording of numbers for a specific user using `/api/values/{userName}/stop`  
1. You can see the number of recording threads/tasks using `/api/values/returntasks`  
1. You can see the current list of ints using `/api/values/returnints` 
1. You can start the recording for user "double" which counts twice as fast and +2 instead of +1 using `/api/values/double/start`  
 
This is POC that I can create/stop multiple Background threads via WebAPI2