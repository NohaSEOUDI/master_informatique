/*
Attention!!! : illegal combination of modifiers: abstract and static

How can static method be abstract? static methods are not overridden!!
If you want to make your method abstract, make it non static
Abstract methods are designing constructs. You create abstract methods because you want your child classes to override them but
static methods are associated with classes not their instance so they can't be overridden.
*/
