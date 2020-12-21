using System;
using System.Windows.Forms;
using iRobot_Roomba_Movement_Panel.Config;

namespace iRobot_Roomba_Movement_Panel {

  public partial class FormConfig : Form {

    ARC.Config.Sub.PluginV1 _cf;

    public ARC.Config.Sub.PluginV1 GetConfiguration => _cf;

    public FormConfig() {

      InitializeComponent();
    }

    public void SetConfiguration(ARC.Config.Sub.PluginV1 cf) {

      _cf = cf;

      tbUartBaud.Text = _cf.STORAGE[ConfigTitles.BAUD_RATE_UART].ToString();

      tbPCBaud.Text = _cf.STORAGE[ConfigTitles.BAUD_RATE_PC].ToString();

      cbSoftwareBaudrate.BeginUpdate();
      cbSoftwareBaudrate.Items.Clear();
      foreach (EZ_B.Uart.BAUD_RATE_ENUM i in Enum.GetValues(typeof(EZ_B.Uart.BAUD_RATE_ENUM)))
        cbSoftwareBaudrate.Items.Add(i);
      cbSoftwareBaudrate.SelectedItem = (EZ_B.Uart.BAUD_RATE_ENUM)_cf.STORAGE[ConfigTitles.BAUD_RATE_SERIAL];
      cbSoftwareBaudrate.EndUpdate();

      tbSensorPollTime.Text = _cf.STORAGE[ConfigTitles.SENSOR_POLL_TIME_MS].ToString();

      cbConnectionType.BeginUpdate();
      cbConnectionType.Items.Clear();
      foreach (ConfigTitles.PortTypeEnum i in Enum.GetValues(typeof(ConfigTitles.PortTypeEnum)))
        cbConnectionType.Items.Add(i);
      cbConnectionType.SelectedItem = (ConfigTitles.PortTypeEnum)_cf.STORAGE[ConfigTitles.CONNECTION_TYPE];
      cbConnectionType.EndUpdate();

      cbPCPort.BeginUpdate();
      cbPCPort.Items.Clear();
      cbPCPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
      cbPCPort.SelectedItem = _cf.STORAGE[ConfigTitles.PC_COM_PORT];
      cbPCPort.EndUpdate();

      ucPBSoftwareSerialPort.SetConfig((EZ_B.Digital.DigitalPortEnum)_cf.STORAGE[ConfigTitles.EZB_SERIAL_PORT]);

      cbHardwareUARTPort.BeginUpdate();
      cbHardwareUARTPort.Items.Clear();
      for (int x = 0; x < 4; x++)
        cbHardwareUARTPort.Items.Add(x);
      cbHardwareUARTPort.SelectedItem = _cf.STORAGE[ConfigTitles.EZB_UART_PORT];
      cbHardwareUARTPort.EndUpdate();

      scriptButtonPressed.ScriptDefinition = _cf.SCRIPTS[ConfigTitles.SCRIPT_BUTTON_PRESSED];

      cbUseNMS.Checked = Convert.ToBoolean(_cf.STORAGE[ConfigTitles.NMS_POSITION_DATA]);
    }

    private void btnSave_Click(object sender, EventArgs e) {

      try {

        var t = (ConfigTitles.PortTypeEnum)cbConnectionType.SelectedItem;

        if (t == ConfigTitles.PortTypeEnum.PC_COM && cbPCPort.SelectedIndex == -1)
          throw new Exception("A PC COM Port must be selected if PC COM mode is selected");

        _cf.SCRIPTS[ConfigTitles.SCRIPT_BUTTON_PRESSED] = scriptButtonPressed.ScriptDefinition;

        _cf.STORAGE[ConfigTitles.BAUD_RATE_UART] = Convert.ToInt32(tbUartBaud.Text.Trim());

        _cf.STORAGE[ConfigTitles.BAUD_RATE_PC] = Convert.ToInt32(tbPCBaud.Text.Trim());

        _cf.STORAGE[ConfigTitles.BAUD_RATE_SERIAL] = cbSoftwareBaudrate.SelectedItem;

        _cf.STORAGE[ConfigTitles.SENSOR_POLL_TIME_MS] = Convert.ToInt32(tbSensorPollTime.Text.Trim());

        _cf.STORAGE[ConfigTitles.CONNECTION_TYPE] = cbConnectionType.SelectedItem;

        _cf.STORAGE[ConfigTitles.PC_COM_PORT] = cbPCPort.SelectedItem;

        _cf.STORAGE[ConfigTitles.EZB_SERIAL_PORT] = ucPBSoftwareSerialPort.PortDigital;

        _cf.STORAGE[ConfigTitles.EZB_UART_PORT] = cbHardwareUARTPort.SelectedItem;

        _cf.STORAGE[ConfigTitles.NMS_POSITION_DATA] = cbUseNMS.Checked;
      } catch (Exception ex) {

        MessageBox.Show(ex.Message);

        return;
      }

      DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e) {

      DialogResult = DialogResult.Cancel;
    }

    private void cbConnectionType_SelectedIndexChanged(object sender, EventArgs e) {

      var t = (ConfigTitles.PortTypeEnum)cbConnectionType.SelectedItem;

      if (t == ConfigTitles.PortTypeEnum.HW_UART) {

        gbPC.Enabled = false;
        gbSoftware.Enabled = false;
        gbUART.Enabled = true;
      } else if (t == ConfigTitles.PortTypeEnum.PC_COM) {

        gbPC.Enabled = true;
        gbSoftware.Enabled = false;
        gbUART.Enabled = false;
      } else if (t == ConfigTitles.PortTypeEnum.Software_Serial) {

        gbPC.Enabled = false;
        gbSoftware.Enabled = true;
        gbUART.Enabled = false;
      }
    }
  }
}
