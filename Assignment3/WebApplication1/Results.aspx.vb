Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objTaxPayer As TaxPayerStructure = clsTaxPayerDA.getTaxPayer(Session("TaxPayer"))
        lblTaxPayerID.Text = Session("TaxPayer")
        txtLastName.Text = objTaxPayer.strTaxPayerLastName
        txtFirstName.Text = objTaxPayer.strTaxPayerFirstName
        txtMI.Text = objTaxPayer.strTaxPayerInitial
        txtCity.Text = objTaxPayer.strTaxPayerCity
        txtState.Text = objTaxPayer.strTaxPayerState
        txtZip.Text = objTaxPayer.strTaxPayerZip


        Dim objTaxReturnDA = clsTaxReturnDA.getTaxReturn(Session("TaxPayer"), Session("TaxReturn"))

        If objTaxReturnDA.NumberOfTaxpayers = 1 Then
            lblIndivOrJoint.Text = "Individual"
        ElseIf objTaxReturnDA.NumberOfTaxpayers = 2 Then
            lblIndivOrJoint.Text = "Joint"
        End If
        txtWages.Text = objTaxReturnDA.Wages
        txtTaxableInterest.Text = objTaxReturnDA.TaxableInterest
        txtUnemploymentCompensation.Text = objTaxReturnDA.UnemploymentCompensation
        txtIncomeTaxWithheld.Text = objTaxReturnDA.IncomeTaxWithheld
        txtEIC.Text = objTaxReturnDA.EIC
        txtCombatPay.Text = objTaxReturnDA.CompatPay

        objTaxReturnDA.calculateTaxReturn()

        lblGrossIncome.Text = objTaxReturnDA.AdjustedGrossIncome
        lblDependents.Text = objTaxReturnDA.mstrNumberOfDependentTaxpayers
        lblDeductions.Text = objTaxReturnDA.ExcemptionAmount
        lblTaxableIncome.Text = objTaxReturnDA.TaxableIncome
        lblTotalPayments.Text = objTaxReturnDA.TotalPayments
        lblTax.Text = objTaxReturnDA.Tax

        lblReturnAmount.Text = objTaxReturnDA.calculateTaxReturn

    End Sub

    Protected Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class