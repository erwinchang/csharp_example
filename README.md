# csharp_example

## XML Parse

```
Unknown: XmlDeclaration
Start Element: Device. Has Attributes? : True
Start Element: Manufacturer. Has Attributes? : False
Inner Text: ROHDE&SCHWARZ
End Element: Manufacturer
Start Element: Model. Has Attributes? : False
Inner Text: HMP2020
End Element: Model
Start Element: SerialNumber. Has Attributes? : False
Inner Text: 102523
End Element: SerialNumber
Start Element: FirmwareRevision. Has Attributes? : False
Inner Text: 2.70
End Element: FirmwareRevision
Start Element: ManufacturerDescription. Has Attributes? : False
Inner Text: Rohde & Schwarz GmbH & Co. KG
End Element: ManufacturerDescription
Start Element: HomepageURL. Has Attributes? : False
Inner Text: www.rohde-schwarz.com
End Element: HomepageURL
Start Element: DriverURL. Has Attributes? : False
Inner Text: www.rohde-schwarz.com
End Element: DriverURL
Start Element: UserDescription. Has Attributes? : False
Inner Text: R&S HMP2020-102523
End Element: UserDescription
Start Element: IdentificationURL. Has Attributes? : False
Inner Text: http://192.168.1.10/lxi/identifcation
End Element: IdentificationURL
Start Element: Interface. Has Attributes? : True
Start Element: InstrumentAddressString. Has Attributes? : False
Inner Text: TCPIP::192.168.1.10::INSTR
```

<a href="https://imgur.com/a2U8Yfk"><img src="https://i.imgur.com/a2U8Yfk.png" title="source: imgur.com" style="width:400px;"/></a>

xml file
```
<?xml version="1.0" encoding="UTF-8"?><Device xmlns="http://www.lxistandard.org/InstrumentIdentification/1.0" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:schemaLocation="http://www.lxistandard.org/InstrumentIdentification/1.0"><Manufacturer>ROHDE&amp;SCHWARZ</Manufacturer><Model>HMP2020</Model><SerialNumber>102523</SerialNumber><FirmwareRevision>2.70</FirmwareRevision><ManufacturerDescription>Rohde &amp; Schwarz GmbH &amp; Co. KG</ManufacturerDescription><HomepageURL>www.rohde-schwarz.com</HomepageURL><DriverURL>www.rohde-schwarz.com</DriverURL><UserDescription>R&amp;S HMP2020-102523</UserDescription><IdentificationURL>http://192.168.1.10/lxi/identifcation</IdentificationURL><Interface xsi:type="NetworkInformation" InterfaceType="VXI" IPType="IPv4" InterfaceName="eth0"><InstrumentAddressString>TCPIP::192.168.1.10::INSTR</InstrumentAddressString><InstrumentAddressString>TCPIP::192.168.1.10::5025::SOCKET</InstrumentAddressString><Hostname>192.168.1.10</Hostname><IPAddress>192.168.1.10</IPAddress><SubnetMask>255.255.255.0</SubnetMask><MACAddress>00-90-B8-23-D2-6E</MACAddress><Gateway>192.168.1.1</Gateway><DHCPEnabled>false</DHCPEnabled><AutoIPEnabled>false</AutoIPEnabled></Interface></Device>
```