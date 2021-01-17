# Dependency Inversion Principle
> High-level modules should not depend on low-level modules.  Both should depend on abstractions.
> Abstractions should not depend on details.  Details should depend on abstractions.

### Some related terms
* **High level** more abstraction, business rules, process oriented, further from i/o
* **Low level** closer to i/o, plumbing code
* **New is glue**

### Typical approach to DIP
* Don't create your own dependencies
* Request dependencies from client
* Client injects dependencies as
    - Construction arguments
    - Properties
    - Method arguments

### Benefits
* Loose coupling
* Easier testing




