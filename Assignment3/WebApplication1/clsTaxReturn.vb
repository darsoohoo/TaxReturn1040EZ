'***********************************************************************************************************************
'Class Name:        clsTaxReturn.vb
'Version:           1.00
'Programmer/s:      Spiros Velianitis
'Date:              Jan 6, 2015
'Purpose:           Perform the necessary calculations for the 1040EZ tax return.
'***********************************************************************************************************************

Public Class clsTaxReturn

    '*******************************************************************************************************************
    'DECLARATION OF CONSTANT VARIABLES
    '*******************************************************************************************************************
    ' -- Constants declared and values initialized
    Private Const mintSTANDARD_DEDUCTION As Integer = 6200, _
              mintEXCEMPTION_DEDUCTION As Integer = 3950, _
              mintMAX_TAXABLE_INCOME_ALLOWED As Integer = 100000, _
              mintMAX_INTEREST_INCOME_ALLOWED As Integer = 1500

    '*******************************************************************************************************************
    'DECLARATION OF MODULE VARIABLES
    '*******************************************************************************************************************
    ' -- Variables to keep track of various information needed to calculate taxes
    Public mintTaxPayerID As Integer, _
            mstrTaxYear As String, _
            mstrNumberOfDependentTaxpayers As String

    Private mdblWages As Double, _
            mdblTaxableInterest As Double, _
            mdblUnemploymentCompensation As Double, _
            mdblAdjustedGrossIncome As Double, _
            mdblExcemptionAmount As Double, _
            mdblTaxableIncome As Double, _
            mdblIncomeTaxWithheld As Double, _
            mdblEIC As Double, _
            mdblCompatPay As Double, _
            mdblTotalPayments As Double, _
            mdblTax As Double, _
            mdblBalance As Double

    Private mintNumberOfTaxpayers As Integer

    '*******************************************************************************************************************
    'CONSTRUCTORS
    '*******************************************************************************************************************
    ' -- Creates a constructor and receives the values from the 1040EZ form in order to do the calculations
    Private Sub New()
        ' Empty default constructor
    End Sub

    Public Sub New(ByVal intTaxPayerID As Integer, ByVal strTaxYear As String, ByVal dblWages As Double, _
                    ByVal dblTaxableInterest As Double, _
                    ByVal dblUnemploymentCompensation As Double, _
                    ByVal dblIncomeTaxWithheld As Double, _
                    ByVal dblEIC As Double, _
                    ByVal dblCompatPay As Double, _
                    ByVal intNumberOfTaxpayers As Integer, _
                    ByVal strNumberOfDependentTaxpayers As String)
        mintTaxPayerID = intTaxPayerID
        mstrTaxYear = strTaxYear
        Wages = dblWages
        TaxableInterest = dblTaxableInterest
        UnemploymentCompensation = dblUnemploymentCompensation
        IncomeTaxWithheld = dblIncomeTaxWithheld
        EIC = dblEIC
        CompatPay = dblCompatPay
        NumberOfTaxpayers = intNumberOfTaxpayers
        NumberOfDependentTaxpayers = strNumberOfDependentTaxpayers

    End Sub

    '*******************************************************************************************************************
    'PROPERTIES
    '*******************************************************************************************************************
    ' -- Various properties to set and access data

    Public Property Wages() As Double
        Get
            Return mdblWages
        End Get
        Set(ByVal Value As Double)
            mdblWages = Value
        End Set
    End Property
    Public Property TaxableInterest() As Double
        Get
            Return mdblTaxableInterest
        End Get
        Set(ByVal Value As Double)
            If Value > mintMAX_INTEREST_INCOME_ALLOWED Then
                Throw New InvalidConstraintException("ERROR TR002. Taxable interest must not be over $ 1,500.00")
            End If
            mdblTaxableInterest = Value
        End Set
    End Property
    Public Property UnemploymentCompensation() As Double
        Get
            Return mdblUnemploymentCompensation
        End Get
        Set(ByVal Value As Double)
            mdblUnemploymentCompensation = Value
        End Set
    End Property
    Public ReadOnly Property AdjustedGrossIncome() As Double
        Get
            Return mdblAdjustedGrossIncome
        End Get
    End Property
    Public ReadOnly Property ExcemptionAmount() As Double
        Get
            Return mdblExcemptionAmount
        End Get
    End Property
    Public ReadOnly Property TaxableIncome() As Double
        Get
            Return mdblTaxableIncome
        End Get
    End Property
    Public Property IncomeTaxWithheld() As Double
        Get
            Return mdblIncomeTaxWithheld
        End Get
        Set(ByVal Value As Double)
            mdblIncomeTaxWithheld = Value
        End Set
    End Property
    Public Property EIC() As Double
        Get
            Return mdblEIC
        End Get
        Set(ByVal Value As Double)
            mdblEIC = Value
        End Set
    End Property

    Public Property CompatPay() As Double
        Get
            Return mdblCompatPay
        End Get
        Set(ByVal Value As Double)
            mdblCompatPay = Value
        End Set
    End Property

    Public ReadOnly Property TotalPayments() As Double
        Get
            Return mdblTotalPayments
        End Get
    End Property
    Public ReadOnly Property Tax() As Double
        Get
            Return mdblTax
        End Get
    End Property

    Public Property NumberOfTaxpayers() As Integer
        Get
            Return mintNumberOfTaxpayers
        End Get
        Set(ByVal Value As Integer)
            mintNumberOfTaxpayers = Value
        End Set
    End Property
    Public Property NumberOfDependentTaxpayers() As String
        Get
            Return mstrNumberOfDependentTaxpayers
        End Get
        Set(ByVal Value As String)
            mstrNumberOfDependentTaxpayers = Value
        End Set
    End Property

    '*******************************************************************************************************************
    'CALCULATE ADJUSTED GROSS INCOME
    '*******************************************************************************************************************
    ' -- Calculates adjusted gross income
    Private Sub calculateAdjustedGrossIncome()
        Me.mdblAdjustedGrossIncome = Me.mdblWages + Me.mdblTaxableInterest + Me.mdblUnemploymentCompensation
    End Sub

    '*******************************************************************************************************************
    'CALCULATE EXCEMPTION AMOUNT
    '*******************************************************************************************************************
    ' -- Calculates excemption amount (information can be found on Form 1040EZ page 2)
    Private Sub calculateExcemptionAmount()
        Dim intNumberOfDependentTaxPayers As Integer
        If mstrNumberOfDependentTaxpayers.StartsWith("1") Then
            intNumberOfDependentTaxPayers = 1
        End If
        If mstrNumberOfDependentTaxpayers.EndsWith("1") Then
            intNumberOfDependentTaxPayers = intNumberOfDependentTaxPayers + 1
        End If

        If intNumberOfDependentTaxPayers = 0 Then
            mdblExcemptionAmount = mintNumberOfTaxpayers * (mintEXCEMPTION_DEDUCTION + mintSTANDARD_DEDUCTION)
        Else
            Dim decA As Double = Me.mdblWages + 350
            Dim decC As Double
            If decA > 1000 Then
                decC = decA
            Else
                decC = 1000
            End If
            Dim decD As Double = mintNumberOfTaxpayers * mintSTANDARD_DEDUCTION
            Dim decE As Double
            If decD > decC Then
                decE = decC
            Else
                decE = decD
            End If
            Dim decF As Double = 0
            If Me.mintNumberOfTaxpayers = 2 AndAlso intNumberOfDependentTaxPayers = 1 Then
                decF = mintEXCEMPTION_DEDUCTION
            End If
            mdblExcemptionAmount = decE + decF
        End If

    End Sub

    '*******************************************************************************************************************
    'CALCULATE TAXABLE INCOME
    '*******************************************************************************************************************
    ' -- Calculates taxable income
    Private Sub calculateTaxableIncome()
        If mdblExcemptionAmount > mdblAdjustedGrossIncome Then
            mdblTaxableIncome = 0
        Else
            mdblTaxableIncome = mdblAdjustedGrossIncome - mdblExcemptionAmount
        End If
    End Sub

    '*******************************************************************************************************************
    'CALCULATE TOTAL PAYMENTS
    '*******************************************************************************************************************
    ' -- Calculates total payments
    Private Sub calculateTotalPayments()
        Me.mdblTotalPayments = Me.mdblIncomeTaxWithheld + Me.mdblEIC
    End Sub

    'Calculate LINE 10
    Private Sub calculateTax()
        Dim myTaxTableRecord As TaxTableStructure = clsTaxRates.findTaxRow(mdblTaxableIncome)

        If Me.mintNumberOfTaxpayers = 1 Then
            Me.mdblTax = myTaxTableRecord.SingleTax
        Else
            Me.mdblTax = myTaxTableRecord.MarriedFilingJointlyTax
        End If
    End Sub

    '*******************************************************************************************************************
    ' Function calculateTaxReturn
    '   This function calls all private sub procedures that calculate
    '   and change the appropriate module level variables (fields)
    ' Returns:
    '   The calculated tax balance
    ' Parameters:
    '   none
    '*******************************************************************************************************************
    Public Function calculateTaxReturn() As Double
        calculateAdjustedGrossIncome()
        calculateExcemptionAmount()
        calculateTaxableIncome()
        If Me.mdblTaxableIncome > mintMAX_TAXABLE_INCOME_ALLOWED Then
            Throw New System.InvalidOperationException("ERROR TR001. Taxable Income cannot exceed $100,000")
        End If
        calculateTotalPayments()
        calculateTax()
        Return Me.mdblTotalPayments - Me.mdblTax
    End Function

End Class
