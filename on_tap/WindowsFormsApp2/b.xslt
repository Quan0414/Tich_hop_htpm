<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="ns"
	xmlns:ns="http://tempuri.org/XMLSchema1.xsd"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
		<head>
			<body>
				<table border="1" cellspacing="0" width="100%">
					<tr>
						<th>STT</th>
						<th>MaSV</th>
						<th>TenSV</th>
						<th>GioiTinh</th>
						<th>NgaySinh</th>
						<th>MaLop</th>
					</tr>

					<xsl:for-each select="ns:lop/ns:sinhvien">
						<xsl:sort select="ns:tensv" data-type="text" order="ascending"/>
						<tr>
							<td>
								<xsl:value-of select="position()"></xsl:value-of>
							</td>
							<td>
								<xsl:value-of select="ns:masv"></xsl:value-of>
							</td>
							<td>
								<xsl:value-of select="ns:tensv"></xsl:value-of>
							</td>
							<td>
								<xsl:value-of select="ns:gioitinh"></xsl:value-of>
							</td>
							<td>
								<xsl:value-of select="ns:ngaysinh"></xsl:value-of>
							</td>
							<td>
								<xsl:value-of select="ns:malop"></xsl:value-of>
							</td>
						</tr>
					</xsl:for-each>
					
				</table>
			</body>
		</head>
    </xsl:template>
</xsl:stylesheet>
