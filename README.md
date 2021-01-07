# WebGate.Azure.CloudTableUtils

WebGate.Azure.CloudTablesUtils provides extensions to CloudTable, which allows direct access in the form of CRUD operation to the entities.
Complex entities, arrays and IEnumerable are also supported.

## Extensions for CloudTable

`using WebGate.Azure.CloudTableUtils.CloudTableExtension`

This Extension enables you to do CRUD Operations with your Poco direct to the CloudTable. The Poco do not have to extend TableEntity. The Object De/Serialisation is done inside of the functions and DynamicTableEntity are used to store and retrieve data.

The following operations are provided:

### GetAllAsync<T>()

```c#
List<MyPoco> pocos = await cloudTable.GetAllAsync<MyPoco>()`
```

Gets all data from a table and convert them into the specified Object. No partition key is applied.

### GetAllAsync<T>(string partition)

```c#
List<MyPoco> pocos = await cloudTable.GetAllAsync<MyPoco>('mypoco')`
```

Gets all data from a table and convert them into the specified Object. A partitionkey is applied. The current example applies 'mypoco' as partitionkey.

### GetByIdAsync<T>(string id)

```c#
MyPoco poco = await.GetByIdAsync<MyPoco>('1018301')`
```

Gets as specific enitity form the table and convert it to the specified object. The name of the type is used as partitionkey. In the current example 'MyPoco'

### GetByIdAsync<T>(string id, string partition)

```c#
MyPoco poco = await.GetByIdAsync<MyPoco>('9201u819','mypoco')`
```

Gets as specific enitity form the table and convert it to the specified object. The partionkey is the 2nd argument.

### GetAllByQueryAsync(TableQuery query)

```c#
TableQuery<DynamicTableEntity> query = new TableQuery<DynamicTableEntity>();
List<MyPoco> pocos = await cloudTable.GetAllByQueryAsync<MyPoco>(query)
```

Gets alls entites that matches the query.

## Code Quality Check SonarCloud.io

[![Quality gate](https://sonarcloud.io/api/project_badges/quality_gate?project=CloudTableUtils&token=b8ea0b7d7b29c7e13fb260bae8cf0d3eb36597ec)](https://sonarcloud.io/dashboard?id=CloudTableUtils)

## Licence

Apache V 2.0

## Copyright

2021, WebGate Consulting AG
