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
