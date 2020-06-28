> ## OO makes code understandable by encapsulating moving parts. FP makes code understandable by minimizing moving parts.

OO is typically about trying to manage the ever changing state of a system, whereas FP is about trying to avoid that state altogether. That is to say, methods are often dependent upon and modify the data associated with a class, whereas the functions in a functional program should depend only on their inputs and not make changes to those values.

## What is functional programming?
FP is a paradigm which concentrates on computing results rather than on performing actions. In other words, FP emphasizes defining functions in terms of their input and output rather than how they change systems state.

FP emphasizes the use of **Expressions** as opposed to **Statements**. Consider the following examples.

Example A :

```cs
string posOrNeg;

if (value > 0)
    posOrNeg = "positive";
else
    posOrNeg = "negative";
```

Example B:

```cs
var posOrNeg =
    value > 0
        ? "positive"
        : "negative";
```

In example `A` we have an unassigned variable and then multiple places where `posOrNeg` is assigned. This is a classic example of the use of the statements. On the hand, in example `B` we use the *ternary operator* to execute for a result. This means that where `posOrNeg` in `A` is assigned as a **side-effect** of the if/else statement, the same variable in `B` is assigned as the **result** of an operator. 

How do we tame side-effects in C#?

One is to enforce immutability within our custom types. By having immutable types, we avoid the possibility that another colleague changes one of the classes properties, negatively affecting our code.

Example of changing a property that will give different results:

```cs
var range = new DateRange 
{ 
    Start = DateTime.Parse("2015-11-01"),
    End = DateTime.Parse("2015-11-06") 
};

testDates.ForEach(d => Console.WriteLine($"{d:yyy-MM-dd} - {range.DateIsInRange(d)}"));
            
// The end date of our mutable type is changed, and the result of the line above changes.
range.End = DateTime.MaxValue;

testDates.ForEach(d => Console.WriteLine($"{d:yyy-MM-dd} - {range.DateIsInRange(d)}"));
```

This can be solved by giving our `DateRange` class private setters and a constructor so that those values cannot be changed from outside the class. This is called **external immutability**.

However, what would happen if we added the following to our class?

```cs
public void Slide(int days)
{
    Start = Start.AddDays(days);
    End = End.AddDays(days);
}
```

Once again, our property values can be changed, although now they are being changed internally rather than externally. And just as there is external immutability, there is also **internal immutability**.

One way to make our `DateRange` class internally immutable would be to create private readonly backing field for our start and end properties like this:

```cs
private readonly DateTime _start;
private readonly DateTime _end;
```

We would then assign these properties through the class constructor, and use the public `Start` and `End` properties to return the values of `_start` and `_end` like this:

```cs
public DateTime Start { get { return _start; } }
public DateTime End { get { return _end; } }
```

## Functional Thinking 

While mutability and expressions are a key part of FP, they do not make a language functional. In order for a language to be considered functional, it must treat functions as **first-class citizens**. 

To treat a function as a first-class citizen, you must pass and return functions as you would any other data type. 
