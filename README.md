# VillaPlus.Exercise

## To run the exercise you need to use the Visual Studio Test Explorer. 

Here is some notes about the exercise.

1) The code is in a single assembly as requested. It should be separated in almost three assemblies
- Pricing: Containung only calculation business logic and promotions
- Contract: Containing public interfaces to let developers extend with specific promotions
- Entities: Probably these comes from an external system. the only have to implement required interfaces for calculation

2) The structure is made to be extensible. PricingCalculator contains logic and promotions can be easily added without changing logic. The best should be to publish it as a nuget package used by implementors.