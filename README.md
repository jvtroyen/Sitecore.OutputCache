# OutputCache #

## What ##

Modified pipelines for Sitecore OutputCache and Rendering Statistics for MVC renderings.

- Processors for adding rendering-statistics for MVC-renderings, viewable on /sitecore/admin/stats.aspx
- Processor for applying the ClearOnIndexUpdate-flag for MVC renderings
- Processor for applying the VaryByContext-flag

## Why ##

OOTB, Sitecore does not provide these functionalities for MVC renderings (Fixed in 8.2)

## Compatibility ##

The module was created and tested on Sitecore 8.1 update-3.

## Usage ##

### Installation ###

The module is made available on the Sitecore marketplace as a Sitecore package. The package includes:

- a template for the VaryByContext option
- a config file that includes pipeline processors
- the dll
 
## History ##
- v1.0 : first version
