# Overview #
This is Web-Application Backend for showing in detail an modern way to creating a backend infrastructure at changing requirements set for. I'm created custom API for requests, separate lay of buisness logic and realise DDD- design that relies on services work. Although this does not give me any db performance (one db used not separating to db-for-read and db-for-write) but gives a pure and clearly way for separating logical process without mixup of writing and reading to entity. So cqrs gives than great opportunity.

Some simplicity has in implementation in anything that I'm not focus on.  

## Features ##
Docker supported.
Swagger in use instead of Frontend

## How it uses ##
### IIS / VS ###
just run project

### Docker ###
You may use theese Powershell commands:


get Image to Docker:

    docker build -f "ApplicationLayer/Dockerfile" --force-rm -t applicationlayer "Full path to project's folder HERE"

Making an Docker's Container

    docker run --rm -p 5000:5000 -e ASPNETCORE_URLS=http://+:5000 applicationlayer

then you should navigate at browser: 

    localhost:5000/swagger/

As results the Console application started you can see main log of work in there. If Docker is uses then application main log messages places in your Container's Log.