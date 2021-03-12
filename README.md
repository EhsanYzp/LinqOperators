# LinqOperators
Basic Usage Examples of LINQ operators in C#/.NET projects

## List of Available Methods:

### QuerySyntax:
This function is an example of query syntax or query expression syntax. Query syntax is similar to SQL (Structured Query Language) for the database.

### MethodSyntax:
This function is an example of method syntax. Method syntax (also known as fluent syntax) uses extension methods included in the Enumerable or Queryable static class, similar to how you would call the extension method of any class.

### WhereOperator:
This function sample uses a lambda expression as a predicate function to filter input dataset.

### OfTypeOperator:
The OfType operator filters the collection based on the ability to cast an element in a collection to a specified type.
       
### OrderByOperator:
OrderBy sorts the values of a collection in ascending or descending order. It sorts the collection in ascending order by default because ascending keyword is optional here. Use descending keyword to sort collection in descending order.
       
### ThenByOperator:
The OrderBy() method sorts the collection in ascending order based on specified field. Use ThenBy() method after OrderBy to sort the collection on another field in ascending order. Linq will first sort the collection based on primary field which is specified by OrderBy method and then sort the resulted collection in ascending order again based on secondary field specified by ThenBy method.

### GroupByOperator:
The GroupBy operator returns a group of elements from the given collection based on some key value. Each group is represented by IGrouping<TKey, TElement> object. Also, the GroupBy method has eight overload methods, so you can use appropriate extension method based on your requirement in method syntax. The result of GroupBy operators is a collection of groups. For example, GroupBy returns IEnumerable<IGrouping<TKey, Student>> from the Student collection
       
### ToLookUpOperator:
ToLookup is the same as GroupBy; the only difference is GroupBy execution is deferred, whereas ToLookup execution is immediate. Also, ToLookup is only applicable in Method syntax. ToLookup is not supported in the query syntax.
        
### JoinOperator:
The Join operator operates on two collections, inner collection & outer collection. It returns a new collection that contains elements from both the collections which satisfies specified expression. It is the same as inner join of SQL.

### GroupJoinOperator:
The GroupJoin operator joins two sequences based on key and groups the result by matching key and then returns the collection of grouped result and key.

### SelectOperator:
The Select operator always returns an IEnumerable collection which contains elements based on a transformation function. It is similar to the Select clause of SQL that produces a flat result set.
      
### AllOperator:
The All operator evalutes each elements in the given collection on a specified condition and returns True if all the elements satisfy a condition.

### AnyOperator:
Any checks whether any element satisfy given condition or not? 

### ContainsOperator:
Contains operator checks whether a specified element exists in the collection or not and returns a boolean. 

### AggegateOperator:
The aggregation operators perform mathematical operations like Average, Aggregate, Count, Max, Min and Sum, on the numeric property of the elements in the collection.

### AverageOperator:
Average extension method calculates the average of the numeric items in the collection. Average method returns nullable or non-nullable decimal, double or float value.

### CountOperator:
The Count operator returns the number of elements in the collection or number of elements that have satisfied the given condition.

### MaxOperator:
The Max operator returns the largest numeric element from a collection.

### SumOperator:
The Sum Operator calculates the sum of numeric items in the collection.

### ElementAtOperator:
The ElementAt Operator returns an element from the specified index from a given collection. If the specified index is out of the range of a collection then it will throw an Index out of range exception. Please note that index is a zero based index.
 
### ElementAtOrDefaultOperator:
The ElementAtOrDefault operator also returns an element from the specified index from a collaction and if the specified index is out of range of a collection then it will return a default value of the data type instead of throwing an error.

### FirstOperator:
The First operator returns the first element of a collection, or the first element that satisfies the specified condition using lambda expression or Func delegate. If a given collection is empty or does not include any element that satisfied the condition then it will throw InvalidOperation exception.

### FirstOrDefaultOperator:
The FirstOrDefault operator does the same thing as First() method. The only difference is that it returns default value of the data type of a collection if a collection is empty or doesn't find any element that satisfies the condition.

### LastOperator:
The Last operator returns the last element from a collection, or the last element that satisfies the specified condition using lambda expression or Func delegate. If a given collection is empty or does not include any element that satisfied the condition then it will throw InvalidOperation exception.

### LastOrDefaultOperator:
The LastOrDefault operator does the same thing as Last() method. The only difference is that it returns default value of the data type of a collection if a collection is empty or doesn't find any element that satisfies the condition.
        
### SingleOperator:
Returns the only element from a collection, or the only element that satisfies a condition. If Single() found no elements or more than one elements in the collection then throws InvalidOperationException.
        
### SingleOrDefaultOperator:
The same as Single, except that it returns a default value of a specified generic type, instead of throwing an exception if no element found for the specified condition. However, it will thrown InvalidOperationException if it found more than one element for the specified condition in the collection.
        
### SequenceEqualOperator:
The SequenceEqual operator checks whether the number of elements, value of each element and order of elements in two collections are equal or not. If the collection contains elements of primitive data types then it compares the values and number of elements, whereas collection with complex type elements, checks the references of the objects.So, if the objects have the same reference then they considered as equal otherwise they are considered not equal.
        
### ConcatOperator:
The Concat operator appends two sequences of the same type and returns a new sequence (collection).

### DefaultIfEmptyOperator:
The DefaultIfEmpty operator returns a new collection with the default value if the given collection on which DefaultIfEmpty() is invoked is empty. Another overload method of DefaultIfEmpty() takes a value parameter that should be replaced with default value.
        
### EmptyOperator:
The Empty operator is not an extension method of IEnumerable or IQueryable like other LINQ methods. It is a static method included in Enumerable static class. So, you can call it the same way as other static methods like Enumerable.Empty<TResult>(). The Empty() method returns an empty collection of a specified type 
        
### RangeOperator:
The Range operator returns a collection of IEnumerable<T> type with specified number of elements and sequential values starting from the first element.

### RepeatOperator:
The Repeat operator generates a collection of IEnumerable<T> type with specified number of elements and each element contains same specified value.

### DistinctOperator:
The Distinct extension method returns a new collection of unique elements from the given collection.
 
### ExceptOperator:
 The Except operator requires two collections. It returns a new collection with elements from the first collection which do not exist in the second collection (parameter collection).
 
### IntersectOperator:
 The Intersect extension method requires two collections. It returns a new collection that includes common elements that exists in both the collection. 
 
### UnionOperator:
 The Union extension method requires two collections and returns a new collection that includes distinct elements from both the collections.
 
### SkipOperator:
 Skips elements up to a specified position starting from the first element in a sequence.
 
### SkipWhileOperator:
 Skips elements based on a condition until an element does not satisfy the condition. If the first element itself doesn't satisfy the condition, it then skips 0 elements and returns all the elements in the sequence.
 
### TakeOperator:
 Partitioning operators split the sequence (collection) into two parts and returns one of the parts. The Take() extension method returns the specified number of elements starting from the first element.
      
### TakeWhileOperator:
 The TakeWhile extension method returns elements from the given collection until the specified condition is true. If the first element itself doesn't satisfy the condition then returns an empty collection.
     
### ToListAndToArrayOperators:
 ToList converts collection to list. ToArray converts a collection to an array
      
### ToDictionaryOperator:
 Converts a Generic list to a generic dictionary
 
 
