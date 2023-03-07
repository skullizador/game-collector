<h1 align="center"> Game Collector </h1> <br>

<p align="center">
  This microservice is responsible for managing competitions, games and odds. All the data for this service comes from the Bookmaker Integration Service and here is processed into a specific competition's game with the odds of each bookmaker. After processing the data, the information is sent to the Arbitrage Finder Service in order to calculate sure bets.  
</p>

## Table of Contents

- [Domain](#introduction)
- [Features](#features)
- [Requirements](#requirements)
- [Quick Start](#quick-start)

## Domain

![Domain](https://github.com/skullizador/game-collector/blob/main/resources/domain.png)

## Features

* Create competition :heavy_check_mark:
* Update competition :heavy_check_mark:
* Delete competition :heavy_check_mark:
* Get competition information :heavy_check_mark:
* Get all competitions :heavy_check_mark:
* Create game in competition :heavy_check_mark:
* Update game :heavy_check_mark:
* Update live game :heavy_check_mark:
* Delete game :heavy_check_mark:
* Get games in a competition :heavy_check_mark:
* Get game information :heavy_check_mark:
* Create odd :heavy_check_mark:
* Update odd :heavy_check_mark:
* Delete odd :heavy_check_mark:
* Get odds in a game :heavy_check_mark:
* Get odds information :heavy_check_mark:

## Requirements
The application can be run locally or in a docker container, the requirements for each setup are listed below.

### Docker
* [Docker](https://www.docker.com/get-docker)

## Quick Start 
### Run Docker

First build the image:
```bash
$ docker build . -t game-collector:{version}
```

When ready, run it:
```bash
$ docker run -p {port:port} game-collector:{version}
```

Application will run by default on port `5000`