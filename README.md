# Waes - Technical Assessment Test
## Diff Compare between two base64 data

The solution provides endpoints to compare two data encoded in base64

## ENDPOINTS
The solution provides 3 endpoints:

- [POST] /diff/v1/{id}/left
- [POST] /diff/v1/{id}/right
- [GET] /diff/v1/{id}

## Running

Clone the repository
```sh
git clone git@github.com:rgx4/Waes-Technical.git
```

Restore the NuGet dependencies.

```sh
dotnet restore
```

Run the application

```sh
dotnet run
```
## EXAMPLES

##### Equal data
Post Left
```sh
curl -X POST "https://localhost:44301/diff/v1/1/left" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"data\":\"V0FFUyB0ZWNobmljYWw=\"}"
```
Post Right
```sh
curl -X POST "https://localhost:44301/diff/v1/1/right" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"data\":\"V0FFUyB0ZWNobmljYWw=\"}"
```

Get
```sh
curl -X GET "https://localhost:44301/diff/v1/1" -H  "accept: */*"
```

Response
```sh
{
    "Message":"The two data are equal"
}
```

#### Same length, different data
Post Left
```sh
curl -X POST "https://localhost:44301/diff/v1/3/left" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"data\":\"d2FlcyB0ZWNobmljYWw=\"}"
```
Post Right
```sh
curl -X POST "https://localhost:44301/diff/v1/3/right" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"data\":\"V0FFUyB0ZWNobmljYWw=\"}"
```

Get
```sh
curl -X GET "https://localhost:44301/diff/v1/3" -H  "accept: */*"
```

Response
```sh
{
    "Message":"The data are of the same length but have differences",
    "Differences":
        [{
            "Offset":0,
            "Length":4
        }]
}
```


## Suggestions for improvement

- New endpoints to edit or delete data
- A Cache tool to avoid unnecessarily requests
- A better database - I used an in-memory database

