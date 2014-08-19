using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParameterValidator
{
    public class ValidationParameterInspector : IParameterInspector
    {
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            if (operationName == "GetData")
            {
                for (int index = 0; index < outputs.Length; index++)
                {
                    if (index == 0)
                    {

                        // execute the method level validators
                        if (((int)outputs[index] < 0) || ((int)outputs[index] > 5))
                            throw new FaultException("Your Error Message");
                    }

                }

            }
            //throw new NotImplementedException();
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            if (operationName == "CreateEmployee")
            {
                for (int index = 0; index < inputs.Length; index++)
                {
                    if (index == 0)
                    {
                        // execute the method level validators
                        //if (((int)inputs[index] < 0) || ((int)inputs[index] > 5))
                          //  throw new FaultException("Validation Input Error");
                        char[] SpecialChars = "!@#$%^&*()".ToCharArray();
                        int indexOf = inputs[0].ToString().IndexOfAny(SpecialChars);
                        if (indexOf != -1)
                        {
                            //special chars
                            throw new FaultException("Validation Input Error");
                        }
                    }

                }

            }
            return null;
         //   throw new NotImplementedException();
        }
    }


    class ValidationBehavior : IEndpointBehavior
    {
        private bool enabled;
        #region IEndpointBehavior Members

        internal ValidationBehavior(bool enabled)
        {
            this.enabled = enabled;
        }

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public void AddBindingParameters(ServiceEndpoint serviceEndpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        { }

        public void ApplyClientBehavior(
          ServiceEndpoint endpoint,
          ClientRuntime clientRuntime)
        {
            //If enable is not true in the config we do not apply the Parameter Inspector
            if (false == this.enabled)
            {
                return;
            }

            foreach (ClientOperation clientOperation in clientRuntime.Operations)
            {
                clientOperation.ParameterInspectors.Add(
                    new ValidationParameterInspector());
            }

        }

        public void ApplyDispatchBehavior(
           ServiceEndpoint endpoint,
           EndpointDispatcher endpointDispatcher)
        {
            //If enable is not true in the config we do not apply the Parameter Inspector

            if (false == this.enabled)
            {
                return;
            }

            foreach (DispatchOperation dispatchOperation in endpointDispatcher.DispatchRuntime.Operations)
            {

                dispatchOperation.ParameterInspectors.Add(
                    new ValidationParameterInspector());
            }

        }

        public void Validate(ServiceEndpoint serviceEndpoint)
        {

        }

        #endregion
    }

    public class CustomBehaviorSection : BehaviorExtensionElement
    {

        private const string EnabledAttributeName = "enabled";

        [ConfigurationProperty(EnabledAttributeName, DefaultValue = true, IsRequired = false)]
        public bool Enabled
        {
            get { return (bool)base[EnabledAttributeName]; }
            set { base[EnabledAttributeName] = value; }
        }

        protected override object CreateBehavior()
        {
            return new ValidationBehavior(this.Enabled);

        }

        public override Type BehaviorType
        {

            get { return typeof(ValidationBehavior); }


        }
    }

}
