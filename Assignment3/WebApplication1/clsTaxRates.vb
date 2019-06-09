'***********************************************************************************************************************
'Class Name:        clsTaxRates.vb
'Version:           1.00
'Programmer/s:      Spiros Velianitis
'Date:              Jan 6, 2015
'Purpose:           Calculates the tax for all taxpayers using the tax tables
'***********************************************************************************************************************
Imports System.Data.SqlClient

Public Class clsTaxRates
    Public Shared Function findTaxRow(ByVal dblTaxableIncome As Double) As TaxTableStructure
        Dim connection As SqlConnection = clsConnection.getConnection()
        Try
            Dim strSelectStatement As String = "SELECT * from [TaxReturn2014].[dbo].[tblTaxTable] WHERE [AtLeast] <= " & dblTaxableIncome & " AND [ButLessThan] > " & dblTaxableIncome
            'Dim strSelectStatement2 As String = "SELECT * FROM [TaxReturn2014].[dbo].[tblTaxTable] where [atleast] > 1200 And [butlessthan] < 1260"
            Dim command As New SqlCommand(strSelectStatement, connection)
            connection.Open()
            Dim reader As SqlDataReader = command.ExecuteReader(CommandBehavior.SingleRow)

            Dim myTaxTableRecord As New TaxTableStructure

            If reader.Read Then
                myTaxTableRecord.AtLeast = dblTaxableIncome
                myTaxTableRecord.ButLessThan = CDbl(reader("ButLessThan"))
                myTaxTableRecord.HeadOfHouseholdTax = CDbl(reader("HeadOfHousehold"))
                myTaxTableRecord.MarriedFilingJointlyTax = CDbl(reader("MarriedFilingJointly"))
                myTaxTableRecord.MarriedFilingSeparatelyTax = (reader("MarriedFilingSeparately"))
                myTaxTableRecord.SingleTax = CDbl(reader("Single"))
                Return myTaxTableRecord
            Else
                Throw New ArgumentException("ERROR DB124: Tax Table record for this taxable income cannot be found")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            connection.Close()
        End Try
    End Function

End Class
