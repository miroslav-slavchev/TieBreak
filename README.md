**How to Run Playwright .NET Tests Workflow**

This document provides a quick guide on how to manually trigger and view the results of the Playwright .NET Tests GitHub Actions workflow.
The single-threaded workflow is configured to run automatically on pushes to the master branch, and it can also be triggered manually using the workflow_dispatch event and the multi-threaded - workflow dispatch only.

Running the Workflow Manually
To run the workflow manually from the GitHub UI:

1. Navigate to your Repository: Go to your GitHub repository where this workflow YAML file is located.
2. Go to the Actions Tab: Click on the "Actions" tab at the top of your repository page.
3. Select the Workflow: In the left sidebar, find and click on the "Playwright .NET Tests" workflow.
4. Run Workflow Button: On the workflow's main page, you'll see a section like "This workflow has a workflow_dispatch event trigger." Click on the "Run workflow" dropdown button.
5. Trigger Workflow: Click the "Run workflow" button within the dropdown. This will start a new workflow run.
![image](https://github.com/user-attachments/assets/2fa94740-8bc7-4215-87f9-4e4260e45896)

**Viewing Workflow Results and Reports**

Once the workflow starts and completes:

Monitor the Run: You'll be redirected to the workflow run page. Here, you can see the progress of each job (test-inventory and test-shopping-cart) in real-time.
![image](https://github.com/user-attachments/assets/37b03700-b792-465c-8382-70da07159941)
