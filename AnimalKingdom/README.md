## Diagrama UML

```mermaid
classDiagram
    class Animal {
        <<abstract>>
        +string Sound()
    }

    class Cat {
        +string Sound()
    }

    class Dog {
        +string Sound()
    }

    Animal <|-- Cat
    Animal <|-- Dog