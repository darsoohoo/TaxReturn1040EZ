Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnViewReturn_Click(sender As Object, e As EventArgs) Handles btnViewReturn.Click
        Session("TaxPayer") = lstID.SelectedValue

        Session("TaxReturn") = CInt(txtTaxYear.Text)

        Response.Redirect("Results.aspx")
    End Sub
End Class