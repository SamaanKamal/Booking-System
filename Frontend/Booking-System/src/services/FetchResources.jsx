const REQUEST_OPTIONS = {
  method: "GET",
};
const BASE_URL = import.meta.env.VITE_API_BASE_URL;

export async function FetchResources() {
  const response = await fetch(`${BASE_URL}/api/v1/Resource`, REQUEST_OPTIONS);
  if (!response.ok) {
    const errorDetails = await response.text();
    throw new Error(
      `Error fetching resources: ${response.status} ${response.statusText}. Details: ${errorDetails}`
    );
    // throw new Error('Failed to fetch resources');
  }
  const data = await response.json();

  return data;
}
